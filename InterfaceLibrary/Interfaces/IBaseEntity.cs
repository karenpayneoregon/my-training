namespace InterfaceLibrary.Interfaces;

/// <summary>
/// Combines the functionalities of <see cref="IIdentity"/> and <see cref="IHuman"/> interfaces.
/// </summary>
/// <remarks>
/// This interface inherits from both <see cref="IIdentity"/> and <see cref="IHuman"/>, 
/// representing an entity that has both a unique identifier and human-related attributes.
/// It is intended to be implemented by classes that require a combination of these functionalities.
/// </remarks>
public interface IBaseEntity : IIdentity, IHuman
{
}
