using System.ComponentModel.DataAnnotations;

namespace Models;

public class HotelRoomDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please enter a room Name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please enter Occupancy")]
    public int Occupancy { get; set; }
    [Range(1,3000,ErrorMessage = "Regular Rate must be between 1 and 3000")]
    public double RegularRate { get; set; }
    public string Details { get; set; }
    public string SqFt { get; set; }
}