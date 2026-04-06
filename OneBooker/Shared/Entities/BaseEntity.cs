namespace OneBooker.Shared.Entities;

/// <summary>
/// Base abstract class for all entities in the project.
/// </summary>
/// <typeparam name="TKey">The type of the entity identifier.</typeparam>
public abstract class BaseEntity<TKey>
{
    /// <summary>
    /// Gets or sets the identifier of the entity.
    /// </summary>
    public TKey Id { get; set; }

    /// <summary>
    /// Gets or sets the time this record has been created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Getsd or sets the last time this record has updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}