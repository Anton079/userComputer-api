namespace UserComputer_api.Computers.Dtos
{
    public class ComputerUpdateRequest
    {
        public string? Type { get; set; }

        public string? Model { get; set; }

        public int? Price { get; set; }

        public int UserId { get; set; }
    }
}
