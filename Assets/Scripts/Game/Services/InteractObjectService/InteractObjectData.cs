namespace Game.Services.InteractObjectService
{
    public readonly struct InteractObjectData
    {
        public readonly EInteractObject InteractObjectName;

        public InteractObjectData(EInteractObject interactObjectName)
        {
            InteractObjectName = interactObjectName;
        }
    }
}