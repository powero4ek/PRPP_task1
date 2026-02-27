using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Form1 : Form
    {
        // Задача 1
        private GroupBox gbTask1;
        private TextBox txtTask1Input;
        private Button btnTask1;
        private TextBox txtTask1Result;

        // Задача 2
        private GroupBox gbTask2;
        private TextBox txtTask2Size;
        private Button btnTask2;
        private TextBox txtTask2Result;

        // Задача 3
        private GroupBox gbTask3;
        private Button btnTask3;
        private TextBox txtTask3Result;

        // Задача 4
        private GroupBox gbTask4;
        private TextBox txtTask4Input;
        private Button btnTask4New;
        private Button btnTask4InPlace;
        private TextBox txtTask4Result;

        // Задача 5
        private GroupBox gbTask5;
        private TextBox txtTask5Input;
        private Button btnTask5;
        private TextBox txtTask5Result;

        // Задача 6
        private GroupBox gbTask6;
        private TextBox txtTask6Input;
        private Button btnTask6;
        private TextBox txtTask6Result;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Манипуляции с массивами";
            this.Size = new Size(1200, 900);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            // Создаем все GroupBox'ы
            CreateTask1();
            CreateTask2();
            CreateTask3();
            CreateTask4();
            CreateTask5();
            CreateTask6();

            // Располагаем GroupBox'ы в два столбца
            // Левый столбец (x = 20)
            gbTask1.Location = new Point(20, 20);
            gbTask2.Location = new Point(20, gbTask1.Bottom + 20);
            gbTask3.Location = new Point(20, gbTask2.Bottom + 20);

            // Правый столбец (x = 620)
            gbTask4.Location = new Point(620, 20);
            gbTask5.Location = new Point(620, gbTask4.Bottom + 20);
            gbTask6.Location = new Point(620, gbTask5.Bottom + 20);

            // Добавляем все на форму
            this.Controls.AddRange(new Control[] {
                gbTask1, gbTask2, gbTask3,
                gbTask4, gbTask5, gbTask6
            });
        }

        // Задача 1: Сумма 10 чисел
        private void CreateTask1()
        {
            gbTask1 = new GroupBox { Text = "Задача 1: Сумма 10 чисел", Size = new Size(580, 160) };

            Label lblInput = new Label { Text = "Введите 10 чисел через пробел:", Location = new Point(10, 25), AutoSize = true };
            txtTask1Input = new TextBox { Location = new Point(10, 45), Width = 400, Font = new Font("Consolas", 9) };

            btnTask1 = new Button { Text = "Вычислить сумму", Location = new Point(420, 42), Width = 130, Height = 27 };

            Label lblResult = new Label { Text = "Результат:", Location = new Point(10, 80), AutoSize = true };
            txtTask1Result = new TextBox { Location = new Point(10, 100), Width = 540, Height = 25, ReadOnly = true, BackColor = Color.White };

            btnTask1.Click += BtnTask1_Click;

            gbTask1.Controls.AddRange(new Control[] { lblInput, txtTask1Input, btnTask1, lblResult, txtTask1Result });
        }

        private void BtnTask1_Click(object? sender, EventArgs e)
        {
            try
            {
                int[] arr = ParseNumbers(txtTask1Input.Text, 10);
                int sum = 0;
                foreach (int x in arr) sum += x;
                txtTask1Result.Text = $"Сумма = {sum}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Задача 2: Макс/мин в случайном массиве размера N
        private void CreateTask2()
        {
            gbTask2 = new GroupBox { Text = "Задача 2: Максимум и минимум (случайный массив)", Size = new Size(580, 200) };

            Label lblSize = new Label { Text = "Размер N:", Location = new Point(10, 25), AutoSize = true };
            txtTask2Size = new TextBox { Location = new Point(80, 22), Width = 50, Font = new Font("Consolas", 9) };

            btnTask2 = new Button { Text = "Сгенерировать и найти", Location = new Point(150, 20), Width = 160, Height = 27 };

            Label lblResult = new Label { Text = "Результат:", Location = new Point(10, 60), AutoSize = true };
            txtTask2Result = new TextBox { Location = new Point(10, 80), Width = 540, Height = 100, ReadOnly = true, BackColor = Color.White, Multiline = true, ScrollBars = ScrollBars.Vertical };

            btnTask2.Click += BtnTask2_Click;

            gbTask2.Controls.AddRange(new Control[] { lblSize, txtTask2Size, btnTask2, lblResult, txtTask2Result });
        }

        private void BtnTask2_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtTask2Size.Text, out int n) || n <= 0)
                    throw new Exception("Введите положительное целое число N.");

                Random rnd = new Random();
                int[] arr = new int[n];
                for (int i = 0; i < n; i++)
                    arr[i] = rnd.Next(1, 101);

                int max = arr[0], min = arr[0];
                int maxIndex = 0, minIndex = 0;
                for (int i = 1; i < n; i++)
                {
                    if (arr[i] > max) { max = arr[i]; maxIndex = i; }
                    if (arr[i] < min) { min = arr[i]; minIndex = i; }
                }

                txtTask2Result.Text = $"Массив: {string.Join(" ", arr)}{Environment.NewLine}";
                txtTask2Result.AppendText($"Максимум = {max} (индекс {maxIndex}){Environment.NewLine}");
                txtTask2Result.AppendText($"Минимум = {min} (индекс {minIndex})");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Задача 3: Четные/нечетные (15 случайных)
        private void CreateTask3()
        {
            gbTask3 = new GroupBox { Text = "Задача 3: Чётные и нечётные (15 случайных)", Size = new Size(580, 160) };

            btnTask3 = new Button { Text = "Сгенерировать массив", Location = new Point(10, 25), Width = 150, Height = 27 };

            Label lblResult = new Label { Text = "Результат:", Location = new Point(10, 60), AutoSize = true };
            txtTask3Result = new TextBox { Location = new Point(10, 80), Width = 540, Height = 50, ReadOnly = true, BackColor = Color.White, Multiline = true };

            btnTask3.Click += BtnTask3_Click;

            gbTask3.Controls.AddRange(new Control[] { btnTask3, lblResult, txtTask3Result });
        }

        private void BtnTask3_Click(object? sender, EventArgs e)
        {
            Random rnd = new Random();
            int[] arr = new int[15];
            for (int i = 0; i < 15; i++)
                arr[i] = rnd.Next(10, 51);

            int even = 0, odd = 0;
            foreach (int num in arr)
            {
                if (num % 2 == 0) even++;
                else odd++;
            }

            txtTask3Result.Text = $"Массив: {string.Join(" ", arr)}{Environment.NewLine}";
            txtTask3Result.AppendText($"Чётных: {even}, Нечётных: {odd}");
        }

        // Задача 4: Реверс массива
        private void CreateTask4()
        {
            gbTask4 = new GroupBox { Text = "Задача 4: Реверс массива (5 чисел)", Size = new Size(580, 210) };

            Label lblInput = new Label { Text = "Введите 5 чисел через пробел:", Location = new Point(10, 25), AutoSize = true };
            txtTask4Input = new TextBox { Location = new Point(10, 45), Width = 400, Font = new Font("Consolas", 9) };

            btnTask4New = new Button { Text = "Реверс (новый)", Location = new Point(420, 42), Width = 130, Height = 27 };
            btnTask4InPlace = new Button { Text = "Реверс (на месте)", Location = new Point(420, 72), Width = 130, Height = 27 };

            Label lblResult = new Label { Text = "Результат:", Location = new Point(10, 110), AutoSize = true };
            txtTask4Result = new TextBox { Location = new Point(10, 130), Width = 540, Height = 60, ReadOnly = true, BackColor = Color.White, Multiline = true };

            btnTask4New.Click += BtnTask4New_Click;
            btnTask4InPlace.Click += BtnTask4InPlace_Click;

            gbTask4.Controls.AddRange(new Control[] { lblInput, txtTask4Input, btnTask4New, btnTask4InPlace, lblResult, txtTask4Result });
        }

        private void BtnTask4New_Click(object? sender, EventArgs e)
        {
            try
            {
                int[] original = ParseNumbers(txtTask4Input.Text, 5);
                int[] reversed = new int[5];
                for (int i = 0; i < 5; i++)
                    reversed[i] = original[4 - i];

                txtTask4Result.Text = $"Исходный: {string.Join(" ", original)}{Environment.NewLine}";
                txtTask4Result.AppendText($"Реверсированный (новый): {string.Join(" ", reversed)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnTask4InPlace_Click(object? sender, EventArgs e)
        {
            try
            {
                int[] arr = ParseNumbers(txtTask4Input.Text, 5);
                for (int i = 0; i < arr.Length / 2; i++)
                {
                    int temp = arr[i];
                    arr[i] = arr[arr.Length - 1 - i];
                    arr[arr.Length - 1 - i] = temp;
                }
                txtTask4Result.Text = $"Результат (на месте): {string.Join(" ", arr)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Задача 5: Сдвиг вправо
        private void CreateTask5()
        {
            gbTask5 = new GroupBox { Text = "Задача 5: Циклический сдвиг вправо", Size = new Size(580, 190) };

            Label lblInput = new Label { Text = "Введите числа через пробел:", Location = new Point(10, 25), AutoSize = true };
            txtTask5Input = new TextBox { Location = new Point(10, 45), Width = 400, Font = new Font("Consolas", 9) };

            btnTask5 = new Button { Text = "Выполнить сдвиг", Location = new Point(420, 42), Width = 130, Height = 27 };

            Label lblResult = new Label { Text = "Результат:", Location = new Point(10, 80), AutoSize = true };
            txtTask5Result = new TextBox { Location = new Point(10, 100), Width = 540, Height = 60, ReadOnly = true, BackColor = Color.White, Multiline = true };

            btnTask5.Click += BtnTask5_Click;

            gbTask5.Controls.AddRange(new Control[] { lblInput, txtTask5Input, btnTask5, lblResult, txtTask5Result });
        }

        private void BtnTask5_Click(object? sender, EventArgs e)
        {
            try
            {
                int[] arr = ParseNumbers(txtTask5Input.Text);
                if (arr.Length == 0) throw new Exception("Массив пуст.");

                int last = arr[arr.Length - 1];
                for (int i = arr.Length - 1; i > 0; i--)
                    arr[i] = arr[i - 1];
                arr[0] = last;

                txtTask5Result.Text = $"Результат сдвига: {string.Join(" ", arr)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Задача 6: Подсчет дубликатов
        private void CreateTask6()
        {
            gbTask6 = new GroupBox { Text = "Задача 6: Подсчёт дубликатов (10 чисел)", Size = new Size(580, 220) };

            Label lblInput = new Label { Text = "Введите 10 чисел через пробел:", Location = new Point(10, 25), AutoSize = true };
            txtTask6Input = new TextBox { Location = new Point(10, 45), Width = 400, Font = new Font("Consolas", 9) };

            btnTask6 = new Button { Text = "Подсчитать", Location = new Point(420, 42), Width = 130, Height = 27 };

            Label lblResult = new Label { Text = "Результат:", Location = new Point(10, 80), AutoSize = true };
            txtTask6Result = new TextBox { Location = new Point(10, 100), Width = 540, Height = 100, ReadOnly = true, BackColor = Color.White, Multiline = true, ScrollBars = ScrollBars.Vertical };

            btnTask6.Click += BtnTask6_Click;

            gbTask6.Controls.AddRange(new Control[] { lblInput, txtTask6Input, btnTask6, lblResult, txtTask6Result });
        }

        private void BtnTask6_Click(object? sender, EventArgs e)
        {
            try
            {
                int[] arr = ParseNumbers(txtTask6Input.Text, 10);
                List<int> processed = new List<int>();
                txtTask6Result.Clear();

                for (int i = 0; i < arr.Length; i++)
                {
                    int current = arr[i];
                    if (processed.Contains(current)) continue;

                    int count = 0;
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] == current) count++;
                    }
                    txtTask6Result.AppendText($"Число {current} встречается {count} раз(а){Environment.NewLine}");
                    processed.Add(current);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Вспомогательный метод парсинга чисел
        private int[] ParseNumbers(string input, int expectedCount = -1)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("Строка пуста.");

            var parts = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var numbers = new List<int>();
            foreach (var p in parts)
            {
                if (int.TryParse(p, out int num))
                    numbers.Add(num);
                else
                    throw new Exception($"Некорректное число: {p}");
            }

            if (expectedCount != -1 && numbers.Count != expectedCount)
                throw new Exception($"Ожидалось {expectedCount} чисел, получено {numbers.Count}.");

            return numbers.ToArray();
        }
    }
}