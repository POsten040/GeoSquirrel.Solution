using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeoSquirrelApi.Models
{
  public class Game
  {
    public int GameId { get; set; }
    [Required]
    [StringLength (25)]
    public string Name{ get; set; }

  }
}