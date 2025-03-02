namespace Question_Answer_App.Model
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string? Category { get; set; }
        public string? QuestionTitle { get; set; }
        public string? MakeBy { get; set; }
        public DateTime? MakeDate { get; set; }
   
    }
}
