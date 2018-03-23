using D2CFL.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D2CFL.Data
{
    /// <summary>
    /// Entity for data layer.
    /// </summary>
    /// <seealso cref="T:D2CFL.Data.Interfaces.IEntity"/>
    public class Entity : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>Int number.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}