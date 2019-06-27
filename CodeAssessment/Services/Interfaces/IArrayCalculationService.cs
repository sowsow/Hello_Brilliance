namespace CodeAssessment.Services.Interfaces
{
	using System.Threading.Tasks;

	public interface IArrayCalculationService
	{
		Task<int[]> Reverse(int[] array);

		Task<int[]> DeletePartialElement(int position, int[] array);
	}
}
