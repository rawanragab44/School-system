namespace Web_API_task1.DTO
{
    public class DeptWithStudentNames
    {
        public int Dept { get; set; }
        public string DeptName { get; set; }
        public string ManagerName { get; set; }

        public List<string> StudentNames { get; set; } = new List<string>();

    }
}
