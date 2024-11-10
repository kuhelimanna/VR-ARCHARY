using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// Bulk of XR code taken from https://learn.unity.com/tutorial/creating-bow-and-arrow-gameplay-in-vr-from-vr-with-andrew?projectId=5fbc5135edbc2a0139266a9a

public class Notch : XRSocketInteractor
{
    private Puller puller = null;
    private Arrow currentArrow = null;

    protected override void Awake()
    {
        base.Awake();
        puller = GetComponent<Puller>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        puller.onSelectExited.AddListener(TryToReleaseArrow);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        puller.onSelectExited.RemoveListener(TryToReleaseArrow);
    }

    protected override void OnSelectEntering(XRBaseInteractable interactable)
    {
        base.OnSelectEntering(interactable);
        StoreArrow(interactable);
    }

    private void StoreArrow(XRBaseInteractable interactable)
    {
        if(interactable is Arrow arrow)
        {
            currentArrow = arrow;
        }
    }

    private void TryToReleaseArrow(XRBaseInteractor interactor)
    {
        if (currentArrow)
        {
            ForceDeselect();
            ReleaseArrow();
        }
    }

    private void ForceDeselect()
    {
        base.OnSelectExiting(currentArrow);
        currentArrow.OnSelectExit(this);
    }

    private void ReleaseArrow()
    {
        currentArrow.Release(puller.PullAmount);
        currentArrow = null;
    }

    public override XRBaseInteractable.MovementType? selectedInteractableMovementTypeOverride
    {
        get { return XRBaseInteractable.MovementType.Instantaneous; }
    }
}
