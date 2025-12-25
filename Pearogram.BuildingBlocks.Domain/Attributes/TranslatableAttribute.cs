namespace Pearogram.BuildingBlocks.Domain.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class TranslatableAttribute : Attribute
{
    public string? Label { get; }
    public TranslatableAttribute(string? label = null) => Label = label;
}
