public record EnumDisplayItem(object Value, string DisplayName)
{
    public override string ToString() => DisplayName;
}