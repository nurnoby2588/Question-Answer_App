using Microsoft.AspNetCore.Http.HttpResults;
using Question_Answer_App.Model;
using System.Data;
using System.Data.SqlClient;

namespace Question_Answer_App.DataAccess
{
    public class QuesAnsREpository
    {
        private readonly string _connectionString;

        public QuesAnsREpository(string connectionString)
        {
            _connectionString = connectionString;
        }
        // get all question
        public async Task<List<Question>> GetAllQuestion() {

            List<Question> quesList = new List<Question>();
            using ( var connection = new SqlConnection(_connectionString) )
            {
                await connection.OpenAsync();
                using(var command = new SqlCommand("dbo.sp_OST_Question", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Question question = new Question();
                        question.QuestionID = Convert.ToInt32(reader["QuestionID"]);
                        question.Category = reader["Category"].ToString();
                        question.QuestionTitle = reader["Question"].ToString();
                        question.MakeBy = reader["MakeBy"].ToString();
                        question.MakeDate = reader["MakeDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["MakeDate"]);
                        quesList.Add(question);
                    }
                }

            }

            return quesList;
        
        }
    }
}
