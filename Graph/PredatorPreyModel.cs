using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using PredatorPreyLib;
using System.Text.Json;
using System.IO;
using System.Text;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using System.Windows.Forms;

namespace Graph
{
    public partial class PredatorPreyModel : Form

    {
        const string engWelcomeText = "Welcome to predator-prey simulation model!\n" +
                "In this program you can input three parameters: number of preys, number of predators and time of the process.\n" +
                "However, this program is just a model, so please do not input more than 10000 preys or predators." +
                "\nAnd do not input" +
                " days number more than 250. After your input press button \"Build model\" to build a graph.\n" +
                " After it you can" +
                " save this chart in pdf format";
        const string ruWelcomeText = "Добро пожаловать в программу, моделирующую взаимодействие хищник-жертва!\n" +
                "В этой программе вы можете ввести: число жертв,число хищников и количество дней.\n" +
                "Однако, эта программа является только моделью, так что не вводите число хищников\n или жертв больше 10000. И также" +
                " не стоит вводить число дней более 250.\n После ввода данных нажмите на кнопку \"Построить модель\", чтобы построить\n" +
                "график вашей модели. После построения графика вы можете сохранить его в формате pdf";
        FunctionSeries fs1 = new FunctionSeries() { Title = "Preys", Color = OxyColors.Green };
        FunctionSeries fs2 = new FunctionSeries() { Title = "Predators", Color = OxyColors.Red };
        int i = 0;
        int startPreys = 0;
        int startPredators = 0;
        int days = 0;
        List<double> preys = new List<double>();
        Timer myTimer = new Timer();
        List<double> predators = new List<double>();
        List<double> time = new List<double>();
        EventHandler handler;
        bool engLanguage = true;
        bool bigSize;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public PredatorPreyModel()
        {
            InitializeComponent();
            plotView1.Model = new PlotModel();
            currentValue.Text = ($"Current value: {Convert.ToDouble(coeff.Value) / 10000}");
            welcomeLabel.Text = engWelcomeText;
            handler = TimerEventProcessor;
            myTimer.Interval = 10;
            myTimer.Start();
        }

        /// <summary>
        /// Обработчик события "тик" таймера
        /// отрисовывает очередную часть графика
        /// </summary>
        /// <param name="myObject"></param>
        /// <param name="myEventArgs"></param>
        private void TimerEventProcessor(object myObject, EventArgs myEventArgs)
        {
            if (i == preys.Count())
            {
                MakeChart.Visible = true;
                saveChart.Visible = true;
                loadModel.Visible = true;
                return;
            }
            fs1.Points.Add(new DataPoint(time[i], preys[i]));
            fs2.Points.Add(new DataPoint(time[i], predators[i]));
            plotView1.InvalidatePlot(true);
            i++;
        }

        /// <summary>
        /// Событие, происходящее при нажатии кнопкки построения графика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakeChart_Click(object sender, EventArgs e)
        {
            try
            {
                //очистка прошлых точек
                fs1.Points.Clear();
                fs2.Points.Clear();
                plotView1.Model.Series.Clear();
                plotView1.Model.Series.Add(fs1);
                plotView1.Model.Series.Add(fs2);
                //проверка корректности введённых данных
                startPreys = (int.TryParse(preysCount.Text, out int preysNum) && preysNum > 0 && preysNum <= 10000) ? preysNum :
                    throw new ModelException("Wrong preys value!");
                startPredators = (int.TryParse(predatorsCount.Text, out int predatorsNum) && predatorsNum > 0 && predatorsNum <= 10000)
                    ? predatorsNum :
                    throw new ModelException("Wrong predators value!");
                days = (int.TryParse(daysCount.Text, out int daysNum) && daysNum > 0 && daysNum <= 250) ? daysNum :
                    throw new ModelException("Wrong days value!");
                plotView1.Model.Title = (modelName.Text != "") ? modelName.Text :
                    throw new ModelException("Input model name!");
                if (Math.Max(startPredators, startPreys) * Convert.ToDouble(coeff.Value) / 10000 > 7)
                {
                    throw new ModelException("The model can not be calculated");
                }
                RKF45.a = Convert.ToDouble(coeff.Value) / 10000;
                RKF45.R = Math.Max(startPredators, startPreys) * 10;
                i = 0;
                RKF45.StartCalculations(startPreys, startPredators, days);//вычисления
                preys = RKF45.preys;
                predators = RKF45.predators;
                time = RKF45.time;
                MakeChart.Visible = false;
                saveChart.Visible = false;
                loadModel.Visible = false;
            }
            catch (ModelException ex)
            {
                if (!engLanguage)
                {
                    switch (ex.Message)
                    {
                        case "Wrong preys value!":
                            MessageBox.Show("Неверное число жертв!");
                            break;
                        case "Wrong predators value!":
                            MessageBox.Show("Неверное число хищников!");
                            break;
                        case "Wrong days value!":
                            MessageBox.Show("Неверное число дней!");
                            break;
                        case "Input model name!":
                            MessageBox.Show("Введите название модели!");
                            break;
                        case "The model can not be calculated":
                            MessageBox.Show("Модель не может быть составлена");
                            break;

                    }
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Событие, происходяще при нажатии кнопки сохранения графика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChart_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string path = saveFileDialog.FileName;
            using (var stream = File.Create(path))//по указанному пути создаётся файл
            {
                var pdfExporter = new PdfExporter() { Width = 600, Height = 400 };
                pdfExporter.Export(plotView1.Model, stream);
            }
            //сохранение данных о модели
            if (File.Exists($"{plotView1.Model.Title}.json"))
            {
                if (engLanguage)
                {
                    if (MessageBox.Show($"You already have model with name {plotView1.Model.Title}\nDo you want to replace it?", "",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SerializeModel($"{plotView1.Model.Title}.json");
                    }
                }
                else
                {
                    if (MessageBox.Show($"У вас уже есть модель с названием {plotView1.Model.Title}\nХотите её заменить?", "",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SerializeModel($"{plotView1.Model.Title}.json");
                    }
                }
            }
            else
            {
                SerializeModel($"{plotView1.Model.Title}.json");
            }
        }

        /// <summary>
        /// Метод сериализует в формат JSON информацию о моедли
        /// и записывает по переданному пути в файл
        /// </summary>
        /// <param name="path"></param>
        private void SerializeModel(string path)
        {
            try
            {
                object[] data = { startPreys, startPredators, days, coeff.Value, modelName.Text };
                string jsonStr = JsonSerializer.Serialize(data);
                File.WriteAllText(path, jsonStr, Encoding.UTF8);
            }
            catch (DirectoryNotFoundException)
            {
                if (engLanguage)
                {
                    MessageBox.Show("Directry not found");
                }
                else
                {
                    MessageBox.Show("Папка не найдена");
                }
            }
            catch (IOException)
            {
                if (engLanguage)
                {
                    MessageBox.Show("Error in file writing");
                }
                else
                {
                    MessageBox.Show("Ошибка при записи файла");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Событие, происходящее при наведении курсора на кнопку построения графика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakeChart_MouseEnter(object sender, EventArgs e)
        {
            MakeChart.ForeColor = Color.Green;//цвет букв становится зелёным
        }

        /// <summary>
        /// Событие, происходящее при убирании курсора с кнопки построения графика 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakeChart_MouseLeave(object sender, EventArgs e)
        {
            MakeChart.ForeColor = Color.RoyalBlue;//цвет букв изменяется на первоначальный
        }

        /// <summary>
        /// Событие происходящее при наведении курсора на кнопку сохранения графика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChart_MouseEnter(object sender, EventArgs e)
        {
            saveChart.ForeColor = Color.Green;//цвет букв становится зелёным
        }

        /// <summary>
        /// Событие, происходящее при убирании курсора с кнопки сохранения графика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChart_MouseLeave(object sender, EventArgs e)
        {
            saveChart.ForeColor = Color.RoyalBlue;//цвет букв становится первоначальным
        }

        /// <summary>
        /// Событие, происходящее при нажатии кнопки Start/Начать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            //компоненты окна с выбором языка становятся невидимыми
            //компоненты основного окна становятся видимыми
            startButton.Visible = false;
            ruLang.Visible = false;
            engLang.Visible = false;
            welcomeLabel.Visible = false;
            plotView1.Visible = true;
            preysCount.Visible = true;
            predatorsCount.Visible = true;
            daysCount.Visible = true;
            daysInfo.Visible = true;
            preysInfo.Visible = true;
            predatorsInfo.Visible = true;
            MakeChart.Visible = true;
            saveChart.Visible = true;
            langInfo.Visible = false;
            loadModel.Visible = true;
            nameInfo.Visible = true;
            modelName.Visible = true;
            coeffInfo.Visible = true;
            currentValue.Visible = true;
            coeff.Visible = true;
            //запуск события таймера
            myTimer.Tick += handler;

            plotView1.Model = new PlotModel();
            //в зависимости от языка задаются названия осей
            if (engLanguage)
            {
                plotView1.Model.Axes.Add(new LinearAxis()
                {
                    Position = AxisPosition.Bottom,
                    Title = "Time, days",
                    TitleColor = OxyColors.Black,
                    TitleFontWeight = FontWeights.Bold,
                    TitlePosition = 0.5,
                    ClipTitle = false,
                    TitleFontSize = 15
                });
                plotView1.Model.Axes.Add(new LinearAxis()
                {
                    Position = AxisPosition.Left,
                    Title = "Species number",
                    TitleColor = OxyColors.Black,
                    TitleFontWeight = FontWeights.Bold,
                    TitlePosition = 0.5,
                    ClipTitle = false,
                    TitleFontSize = 15
                });
                plotView1.Model.LegendTitle = "Legend";
            }
            else
            {
                plotView1.Model.Axes.Add(new LinearAxis()
                {
                    Position = AxisPosition.Bottom,
                    Title = "Время, дни",
                    TitleColor = OxyColors.Black,
                    TitleFontWeight = FontWeights.Bold,
                    TitlePosition = 0.5,
                    ClipTitle = false,
                    TitleFontSize = 15
                });
                plotView1.Model.Axes.Add(new LinearAxis()
                {
                    Position = AxisPosition.Left,
                    Title = "Число особей",
                    TitleColor = OxyColors.Black,
                    TitleFontWeight = FontWeights.Bold,
                    TitlePosition = 0.5,
                    ClipTitle = false,
                    TitleFontSize = 15
                });
                plotView1.Model.LegendTitle = "Легенда";
            }
            plotView1.Model.LegendPosition = LegendPosition.TopRight;
        }

        /// <summary>
        /// Событие, происходящее при нажатии кнопки выбора русского языка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RuLang_Click(object sender, EventArgs e)
        {
            startButton.Text = "Начать";
            loadModel.Text = "Загрузить модель";
            welcomeLabel.Text = ruWelcomeText;
            preysInfo.Text = "Число жертв:";
            predatorsInfo.Text = "Число хищников:";
            daysInfo.Text = "Число дней:";
            MakeChart.Text = "Построить график";
            saveChart.Text = "Сохранить график";
            langInfo.Text = "Выберите Ваш язык";
            nameInfo.Text = "Введите название модели:";
            engLanguage = false;
            if (!bigSize)
            {
                modelName.Location = new Point(806, 472);
                nameInfo.Location = new Point(806, 433);
            }
            modelName.Size = nameInfo.Size;
            fs1 = new FunctionSeries() { Title = "Жертвы", Color = OxyColors.Green };
            fs2 = new FunctionSeries() { Title = "Хищники", Color = OxyColors.Red };
            currentValue.Text = $"Текущее значение: {Convert.ToDouble(coeff.Value) / 10000}";
            coeffInfo.Text = "Коэффициент смертности жертв:";

        }

        /// <summary>
        /// Событие, происходящее при нажатии кнопки выбора английского языка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EngLang_Click(object sender, EventArgs e)
        {
            startButton.Text = "Start";
            welcomeLabel.Text = engWelcomeText;
            preysInfo.Text = "Number of preys:";
            predatorsInfo.Text = "Number of predators:";
            daysInfo.Text = "Number of days:";
            MakeChart.Text = "Build chart";
            saveChart.Text = "Save your chart";
            loadModel.Text = "Load model";
            langInfo.Text = "Select your language";
            nameInfo.Text = "Model name:";
            engLanguage = true;
            fs1 = new FunctionSeries() { Title = "Preys", Color = OxyColors.Green };
            fs2 = new FunctionSeries() { Title = "Predators", Color = OxyColors.Red };
            currentValue.Text = $"Current value: {Convert.ToDouble(coeff.Value) / 10000}";
            coeffInfo.Text = "Preys dead coefficient:";
        }

        /// <summary>
        /// Событие, происходящее при наведении курсора на кнопку выбора английского языка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EngLang_MouseEnter(object sender, EventArgs e)
        {
            engLang.ForeColor = Color.Green;//цвет букв становится зелёным
        }

        /// <summary>
        /// Событие, происходящее при убирании курсора с кнопки выбора английского языка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EngLang_MouseLeave(object sender, EventArgs e)
        {
            engLang.ForeColor = Color.AliceBlue;//цвет букв меняется на первоначальный
        }

        /// <summary>
        /// Событие, происходящее при наведении курсора на кнопку выбора русского языка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RuLang_MouseEnter(object sender, EventArgs e)
        {
            ruLang.ForeColor = Color.Green;//цвет букв становится зелёным
        }

        /// <summary>
        /// Событие, происходящее при убирании курсора с кнопки выбора русского языка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RuLang_MouseLeave(object sender, EventArgs e)
        {
            ruLang.ForeColor = Color.AliceBlue;//цвет букв меняется на первоначальный
        }

        /// <summary>
        /// Событие, происходящее при наведении курсора на кнопку Start/Начать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_MouseEnter(object sender, EventArgs e)
        {
            startButton.ForeColor = Color.Green;//цвет букв становится зелёным
        }

        /// <summary>
        /// Событие, происходящее при убирании курсора с кнопки Start/Начать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
        private void StartButton_MouseLeave(object sender, EventArgs e)
        {
            startButton.ForeColor = Color.RoyalBlue;//цвет букв меняетя на первоначальный
        }

        /// <summary>
        /// Событие, происходящее при изменении коэффициента
        /// взаимодействия хищников и жертв
        /// отображает текущее значение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Coeff_Scroll(object sender, EventArgs e)
        {
            if (engLanguage)
            {
                currentValue.Text = $"Current value: {Convert.ToDouble(coeff.Value) / 10000}";
            }
            else
            {
                currentValue.Text = $"Текущее значение: {Convert.ToDouble(coeff.Value) / 10000}";
            }
        }

        /// <summary>
        /// Событие происходящее при нажатии на кнопку загрузки модели
        /// загружает данные ранее сохранённой модели
        /// если они соответсвтуют требованиям
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadModel_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            openFileDialog.InitialDirectory = path;
            openFileDialog.FilterIndex = 0;
            openFileDialog.Filter = "JSON Files (.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string jsonStr = File.ReadAllText(openFileDialog.FileName);
                    List<object> arr = JsonSerializer.Deserialize<List<object>>(jsonStr);
                    if (arr.Count != 5)
                    {
                        throw new ModelException("File was broken");
                    }
                    preysCount.Text = arr[0].ToString();
                    predatorsCount.Text = arr[1].ToString();
                    daysCount.Text = arr[2].ToString();
                    coeff.Value = Convert.ToInt32(arr[3].ToString());
                    if (engLanguage)
                    {
                        currentValue.Text = $"Current value: {Convert.ToDouble(coeff.Value) / 10000}";
                    }
                    else
                    {
                        currentValue.Text = $"Текущее значение: {Convert.ToDouble(coeff.Value) / 10000}";
                    }
                    modelName.Text = arr[4].ToString();
                }
                catch (DirectoryNotFoundException)
                {
                    if (engLanguage)
                    {
                        MessageBox.Show("Directoy not found");
                    }
                    else
                    {
                        MessageBox.Show("Папка не найдена");
                    }
                }
                catch (IOException)
                {
                    if (engLanguage)
                    {
                        MessageBox.Show("Error in file reading");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при чтении файла");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Событие, происходящее при наведении курсора на кнопку загрузки модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadModel_MouseEnter(object sender, EventArgs e)
        {
            loadModel.ForeColor = Color.Green;//цвет букв становится зелёным
        }

        /// <summary>
        /// Событие, происходящее при убирании курсора с кнопки загрузки модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void LoadModel_MouseLeave(object sender, EventArgs e)
        {
            loadModel.ForeColor = Color.RoyalBlue;//цвет принимает первоначальное значение
        }

        /// <summary>
        /// Событие, происходящее при изменении размера окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PredatorPreyModel_SizeChanged(object sender, EventArgs e)
        {
            bigSize = (bigSize) ? false : true;
            if (bigSize)
            {
                welcomeLabel.Font = new Font(welcomeLabel.Font.FontFamily, 16, welcomeLabel.Font.Style);
                welcomeLabel.Location = new Point(261, 57);
                langInfo.Font = new Font(langInfo.Font.FontFamily, 16, langInfo.Font.Style);
                nameInfo.Location = new Point(800, 700);
                modelName.Location = new Point(modelName.Location.X + 50, modelName.Location.Y);
            }
            else
            {
                welcomeLabel.Font = new Font(welcomeLabel.Font.FontFamily, 12, welcomeLabel.Font.Style);
                if (engLanguage)
                {
                    langInfo.Location = new Point(620, 175);
                }
                else
                {
                    langInfo.Location = new Point(560, 175);
                }
                langInfo.Font = new Font(langInfo.Font.FontFamily, 13, langInfo.Font.Style);
                nameInfo.Location = new Point(800, 430);
                modelName.Location = new Point(806, 472);
            }
        }

        /// <summary>
        /// Событие, уточняющее у пользователя точно ли он хочет выйти
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PredatorPreyModel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!engLanguage)
            {
                if (MessageBox.Show("Вы точно хотите выйти?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                if (MessageBox.Show("Do you want to exit?", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
