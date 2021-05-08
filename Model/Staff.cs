
namespace MyStaffWpf2.Model
{
    public class Staff
    {

        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public int PositionId { get; set; }

        public virtual Position Position { get; set; }

        public string DateOfBrith { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public Position PositionById
        {
            get
            {
                return DataWorker.findPositionById(PositionId);
            }
        }


    }
}
