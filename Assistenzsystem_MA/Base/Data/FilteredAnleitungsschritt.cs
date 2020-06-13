namespace Assistenzsystem_MA.Base.Data
{
    public class FilteredAnleitungsschritt : Anleitungsschritt
    {

        public FilteredAnleitungsschritt(Anleitungsschritt anleitungsschritt) : base(anleitungsschritt.Name, anleitungsschritt.AnleitungsmediaWithInfos)
        {

        }

    }

}
