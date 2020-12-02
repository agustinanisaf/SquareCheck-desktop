using SquareCheck_desktop.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Velacro.Api;

namespace SquareCheck_desktop.Api
{
    public class ApiGenerator
    {
        public static string Token { get; set; }

        private static ApiClient GetApiClient()
        {
            return new ApiClient("http://localhost/api");
        }

        private static async Task SetupGetRequest(string _endpoint, Action<HttpResponseBundle> successAction)
        {
            var client = GetApiClient();
            var request = new ApiRequestBuilder()
                .buildHttpRequest()
                .setEndpoint(_endpoint)
                .setRequestMethod(HttpMethod.Get)
                .getApiRequestBundle();

            client.setAuthorizationToken(Token);
            client.setOnSuccessRequest(successAction);
            await client.sendRequest(request);
        }

        public static async Task PostLogin(Action<HttpResponseBundle> successAction, UserModel user)
        {
            string _endpoint = "/auth/login";

            var client = GetApiClient();
            var request = new ApiRequestBuilder()
                .buildHttpRequest()
                .setEndpoint(_endpoint)
                .addParameters("email", user.Email)
                .addParameters("password", user.Password)
                .setRequestMethod(HttpMethod.Post)
                .getApiRequestBundle();

            client.setOnSuccessRequest(successAction);
            var response = await client.sendRequest(request);
            if (response != null && response.getHttpResponseMessage().Content != null)
            {
                Token = response.getParsedObject<TokenModel>().Token;
            }
        }

        public static async Task GetListStudent(Action<HttpResponseBundle> successAction)
        {
            string _endpoint = "/departments/students";

            await SetupGetRequest(_endpoint, successAction);
        }

        public static async Task GetDepartmentListStudent(Action<HttpResponseBundle> successAction, int departmentId)
        {
            string _endpoint = "/departments/:id/students";
            _endpoint = _endpoint.Replace(":id", departmentId.ToString());

            await SetupGetRequest(_endpoint, successAction);
        }

        public static async Task GetStudentListSubject(Action<HttpResponseBundle> successAction, int studentId)
        {
            string _endpoint = "/students/:id/subjects";
            _endpoint = _endpoint.Replace(":id", studentId.ToString());

            await SetupGetRequest(_endpoint, successAction);
        }

        public static async Task GetStudentListAttendance(Action<HttpResponseBundle> successAction, int studentId)
        {
            string _endpoint = "/students/:id/attendances";
            _endpoint = _endpoint.Replace(":id", studentId.ToString());

            await SetupGetRequest(_endpoint, successAction);
        }

        // Can run Multiple time without set another token
        public static async Task GetListSubject(Action<HttpResponseBundle> successAction)
        {
            string _endpoint = "/departments/subjects";

            await SetupGetRequest(_endpoint, successAction);
        }

        public static async Task GetDepartmentListSubject(Action<HttpResponseBundle> successAction, int departmentId)
        {
            string _endpoint = "/departments/:id/subjects";
            _endpoint = _endpoint.Replace(":id", departmentId.ToString());

            await SetupGetRequest(_endpoint, successAction);
        }

        public static async Task GetSubjectListSchedule(Action<HttpResponseBundle> successAction, int subjectId)
        {
            string _endpoint = "/subjects/:id/schedules";
            _endpoint = _endpoint.Replace(":id", subjectId.ToString());

            await SetupGetRequest(_endpoint, successAction);
        }

        public static async Task GetScheduleListAttendance(Action<HttpResponseBundle> successAction, int scheduleId)
        {
            string _endpoint = "/schedules/:id/attendances";
            _endpoint = _endpoint.Replace(":id", scheduleId.ToString());

            await SetupGetRequest(_endpoint, successAction);
        }

        public static async Task EditAttendance(Action<HttpResponseBundle> successAction, int scheduleId, AttendanceModel attendance)
        {
            string _endpoint = "/schedules/:id/attendances";
            _endpoint = _endpoint.Replace(":id", scheduleId.ToString());

            var client = GetApiClient();
            var request = new ApiRequestBuilder()
                .buildHttpRequest()
                .setEndpoint(_endpoint)
                .addParameters("student_id", attendance.StudentId.ToString())
                .addParameters("status", attendance.Status)
                .setRequestMethod(HttpMethod.Put)
                .getApiRequestBundle();

            client.setOnSuccessRequest(successAction);
            await client.sendRequest(request);
        }
    }
}
