using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectB
{
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> CombinationsWithRepetition<T>(this IEnumerable<T> input, int k, IEqualityComparer<T>? comparer = null)
        {
            if (comparer != null && input.Distinct(comparer).Count() != input.Count())
                throw new ArgumentException("Input sequence contains duplicate elements");

            return GetCombinations(input.ToList(), k);
        }

        public static IEnumerable<IEnumerable<T>> Subsets<T>(this IEnumerable<T> input, IEqualityComparer<T>? comparer = null)
        {
            if (comparer != null && input.Distinct(comparer).Count() != input.Count())
                throw new ArgumentException("Input sequence contains duplicate elements");

            return GetSubsets(input.ToList());
        }

        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> input, IEqualityComparer<T>? comparer = null)
        {
            if (comparer != null && input.Distinct(comparer).Count() != input.Count())
                throw new ArgumentException("Input sequence contains duplicate elements");

            return GetPermutations(input.ToList());
        }

        private static IEnumerable<IEnumerable<T>> GetCombinations<T>(List<T> input, int k)
        {
            if (k < 0) throw new ArgumentOutOfRangeException(nameof(k));
            if (k == 0) return new[] { new T[0] };

            // Генерируем сочетания из n по k с повторениями для входной коллекции элементов
            return input.SelectMany((e, i) =>
                // Генерируем сочетания из n по k - 1 с повторениями для списка, состоящего из элементов входной коллекции, начиная с i-го элемента
                GetCombinations(input.Skip(i).ToList(), k - 1)
                    // Для каждого сочетания добавляем текущий элемент в начало сочетания
                    .Select(c => (new[] { e }).Concat(c)));
        }

        private static IEnumerable<IEnumerable<T>> GetSubsets<T>(List<T> input)
        {
            // Генерируем все возможные подмножества элементов входной коллекции
            return Enumerable.Range(0, 1 << input.Count)
                // Для каждого числа в этой последовательности
                .Select(index =>
                    // Фильтруем элементы входной коллекции на основе значения определенного бита в числе index
                    input.Where((v, i) => (index & 1 << i) != 0));
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(List<T> list)
        {
            if (list.Count == 1) return new List<List<T>> { list };

            // Генерируем все возможные перестановки элементов входной коллекции
            return list.SelectMany((t, i) =>
                // Генерируем перестановки для списка, состоящего из всех элементов входной коллекции, кроме текущего элемента
                GetPermutations(list.Where((x, j) => i != j).ToList())
                    // Для каждой перестановки добавляем текущий элемент в начало перестановки
                    .Select(p => (new[] { t }).Concat(p)));
        }
    }
}
