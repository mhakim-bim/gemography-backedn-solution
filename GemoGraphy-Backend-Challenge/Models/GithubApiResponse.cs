namespace GemoGraphy_Backend_Challenge.Models
{
    public class GithubApiResponse
    {
      public int total_count{ get; set; }
      public bool incomplete_results{ get; set; }
      public GithubRepo[] items { get; set; }
    }
}