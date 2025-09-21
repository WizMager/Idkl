namespace Game.Services.InteractObjectService
{
    public readonly struct InteractObjectData
    {
        public readonly EInteractObject InteractObjectName;
        public readonly float BaseTimeForAction;

        public InteractObjectData(
            EInteractObject interactObjectName, 
            float baseTimeForAction
        )
        {
            InteractObjectName = interactObjectName;
            BaseTimeForAction = baseTimeForAction;
        }
    }
}