namespace InterfaceLibrary.Interfaces;
/// <summary>
/// Represents an entity with a unique identifier.
/// </summary>
/// <remarks>
/// This interface is implemented by classes that require an identifier property.
/// It is commonly used to standardize the identification of entities across the application.
/// </remarks>
public interface IIdentity
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    /// <value>
    /// An <see cref="int"/> representing the unique identifier of the entity.
    /// </value>
    /// <remarks>
    /// This property is used to uniquely identify an entity that implements the <see cref="IIdentity"/> interface.
    /// </remarks>
    public int Id { get; set; }
}