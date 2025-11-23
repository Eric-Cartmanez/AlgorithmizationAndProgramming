using System;
using System.Collections.Generic;
using Tasks.VowelOrConsonant;
using Xunit;

namespace Tasks.Tests
{
    public class VowelOrConsonantTests
    {
        public static IEnumerable<object[]> GetTestCases()
        {
            var solution = new Tasks.VowelOrConsonant.VowelOrConsonant();

            // ==========================================
            // ГРУППА 1: ГЛАСНЫЕ буквы (10 штук + регистр)
            // ==========================================
            // Ожидаемый ответ: "Гласная"
            
            char[] vowels = { 
                'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е',
                'А', 'У', 'О', 'Ы', 'И', 'Э', 'Я', 'Ю', 'Ё', 'Е'
            };

            foreach (var c in vowels)
            {
                yield return new object[] { solution, c, "Гласная" };
            }

            // ==========================================
            // ГРУППА 2: СОГЛАСНЫЕ буквы (Остальные русские)
            // ==========================================
            // Ожидаемый ответ: "Согласная"

            char[] consonants = { 
                'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 
                'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ',
                'ъ', 'ь', // Знаки обычно относят к "не гласным" -> Согласная
                'Б', 'В', 'Й', 'Ъ' // Проверка верхнего регистра
            };

            foreach (var c in consonants)
            {
                yield return new object[] { solution, c, "Согласная" };
            }

            // ==========================================
            // ГРУППА 3: ОШИБКИ (Не русские буквы)
            // ==========================================
            // Ожидаемый ответ: "Error"

            yield return new object[] { solution, 'a', "Error" }; // Английская 'a' (код 97)
            yield return new object[] { solution, 'e', "Error" }; // Английская 'e'
            yield return new object[] { solution, 'y', "Error" }; // Английская 'y' (похожа на У)
            yield return new object[] { solution, 'H', "Error" }; // Английская 'H' (похожа на Н)
            
            yield return new object[] { solution, '1', "Error" }; // Цифра
            yield return new object[] { solution, '!', "Error" }; // Спецсимвол
            yield return new object[] { solution, ' ', "Error" }; // Пробел
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void DetermineLetter_ReturnsCorrectCategory(
            IVowelOrConsonantSolution solution, 
            char inputChar, 
            string expectedResult)
        {
            // Act
            string actualResult = solution.DetermineLetter(inputChar);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
