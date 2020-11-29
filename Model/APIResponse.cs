namespace SquareCheck_desktop.Model
{
    public class APIResponse<T>
    {
        public T Data { get; set; }
        public Link Links { get; set; }
        public Meta Meta { get; set; }
    }
}
