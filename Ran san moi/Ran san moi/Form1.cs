using Ran_san_moi.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Ran_san_moi
{
    public partial class Form1 : Form
    {
        // Khai báo Con rắn và Thức ăn
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        // Khai báo Chiều rộng tối đa
        int maxWidth;

        // Khai báo Chiều cao tối đa
        int maxHeight;

        // Khai báo Điểm
        int score;
        
        // Khai báo Điểm cao nhất
        int highScore;
        
        // Tạo biến random
        Random rand = new Random();
        
        // Tạo các biến trái, phải, trên dưới
        bool goLeft, goRight, goUp, goDown;
        
        public Form1()
        {
            InitializeComponent();
            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
            }
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            // Bắt đầu game mới Restart lại hết
            RestartGame();
        }

        // Lưu hình ảnh về máy
        private void TakeSnapShot(object sender, EventArgs e)
        {
            Label caption = new Label();
            caption.Text = "Tôi ghi được: " + score + " Và điểm cao nhất của tôi là: " + highScore + " Bạn có thể làm tốt hơn ???";
            caption.Font = new Font("Ariel", 12, FontStyle.Bold);
            caption.ForeColor = Color.Red;
            caption.AutoSize = false;
            caption.Width = picKhungHinh.Width;
            caption.Height = 30;
            caption.TextAlign = ContentAlignment.MiddleCenter;
            picKhungHinh.Controls.Add(caption);
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Thử thách rắn săn mồi";
            dialog.DefaultExt = "jpg";
            dialog.Filter = "JPG Image File | *.jpg";
            dialog.ValidateNames = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(picKhungHinh.Width);
                int height = Convert.ToInt32(picKhungHinh.Height);
                Bitmap bmp = new Bitmap(width, height);
                picKhungHinh.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                picKhungHinh.Controls.Remove(caption);
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // Lập trình các bước duy chuyển
            if (goLeft)
            {
                Settings.directions = "left";
            }
            if (goRight)
            {
                Settings.directions = "right";
            }
            if (goDown)
            {
                Settings.directions = "down";
            }
            if (goUp)
            {
                Settings.directions = "up";
            }

            // Lập trình khi kết thúc đường đi thì xuất hiện ở hướng đối diện
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                    }
                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;
                    }
                    if (Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }
                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }
                    if (Snake[i].Y > maxHeight)
                    {
                        Snake[i].Y = 0;
                    }
                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                    }

                    // Lập trình kết thúc game nếu Con rắn cắn chính nó
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
            picKhungHinh.Invalidate();
        }

        // Tạo hình ảnh cho Con rắn và Thức ăn
        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush snakeColour;

            // Cho đầu rắn màu đen
            // Cho thân rắn màu xanh đen
            // Gáng kích thước cho sẵn ở Setting
            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                {
                    snakeColour = Brushes.Black;
                }
                else
                {
                    snakeColour = Brushes.DarkGreen;
                }
                canvas.FillEllipse(snakeColour, new Rectangle
                    (
                    Snake[i].X * Settings.Width,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
            }

            // Cho thức ăn màu đỏ đen
            // Gáng kích thước cho sãn ở Setting (Giống y như Con rắn vậy)
            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
            (
            food.X * Settings.Width,
            food.Y * Settings.Height,
            Settings.Width, Settings.Height
            ));
        }
        

        private void RestartGame()
        {
            maxWidth = picKhungHinh.Width / Settings.Width - 1;
            maxHeight = picKhungHinh.Height / Settings.Height - 1;
            Snake.Clear();
            btnBatDau.Enabled = false;
            btnChupAnh.Enabled = false;
            score = 0;
            txtDiem.Text = "Điểm: " + score;
            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head); // Thêm phần đầu của con rắn vào danh sách

            // Kích thước ban đầu của Con rắn là 20
            for (int i = 0; i < 20; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            // Thức ăn được tạo ở vị trí ngẫu nhiên
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
            HenGio.Start();
        }

        // Khi Con rắn ăn thức ăn thì sẽ + thêm 1, thức ăn được rãi ngẫu nhiên trên sân
        private void EatFood()
        {
            score += 1;
            txtDiem.Text = "Điểm: " + score;
            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            Snake.Add(body);
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
        }

        // Khi trò chơi kết thúc sẽ cho biết Điểm ghi được và Điểm cao nhất
        private void GameOver()
        {
            HenGio.Stop();
            btnBatDau.Enabled = true;
            btnChupAnh.Enabled = true;
            if (score > highScore)
            {
                highScore = score;
                txtDiemCaoNhat.Text = "Điểm cao nhất " + Environment.NewLine + highScore;
                txtDiemCaoNhat.ForeColor = Color.Maroon;
                txtDiemCaoNhat.TextAlign = ContentAlignment.MiddleCenter;
            }
        }
    }
}


