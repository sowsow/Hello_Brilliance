namespace CodeAssessment.Services
{
	using System;
	using System.Threading.Tasks;

	using CodeAssessment.Services.Interfaces;

	public class ArrayCalculationService : IArrayCalculationService
	{
		public Task<int[]> Reverse(int[] array)
		{
			Validate(array);

			var result = new int[array.Length];

			for (var i = 0; i < array.Length; i++)
			{
				result[i] = array[array.Length - 1 - i];
			}

			return Task.FromResult(result);
		}

		public Task<int[]> DeletePartialElement(int position, int[] array)
		{
			Validate(position, array);

			var result = new int[array.Length - 1];

			var index = 0;

			for (var i = 0; i < array.Length; i++)
			{
				if (position == i + 1)
				{
					continue;
				}

				result[index++] = array[i];
			}

			return Task.FromResult(result);
		}

		private void Validate(int position, int[] array)
		{
			Validate(array);

			if (position <= 0 || position > array.Length)
			{
				throw new ArgumentOutOfRangeException(nameof(position));
			}
		}

		private void Validate(int[] array)
		{
			if (array == null)
			{
				throw new ArgumentNullException(nameof(array));
			}

			if (array.Length == 0)
			{
				throw new InvalidOperationException($"Input {nameof(array)} cannot be empty.");
			}
		}
	}
}
