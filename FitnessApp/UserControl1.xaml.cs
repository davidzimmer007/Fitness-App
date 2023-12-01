using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessApp
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1(Muskel muskel)
        {
            InitializeComponent();
            GenerateCards(muskel);
        }

        private void GenerateCards(Muskel muskel)
        {
            const int cardsPerRow = 4; 
            const double cardWidth = 250;
            const double cardHeight = 400;
            const double horizontalSpacing = 60; 
            const double verticalSpacing = 80; 

            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Orientation = Orientation.Horizontal;

            for (int i = 0; i < muskel.UebungenListe.Count; i++)
            {
                StackPanel cardView = new StackPanel();
                cardView.Width = cardWidth;
                cardView.Height = cardHeight;
                cardView.Background = new SolidColorBrush(Colors.LightGray);
                cardView.VerticalAlignment = VerticalAlignment.Stretch;

                Label label = new Label();
                label.Content = muskel.UebungenListe[i].Name;
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.Margin = new Thickness(5,5,5,5);
                label.FontSize = 20;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource =muskel.UebungenListe[i].Image;
                bitmap.EndInit();

                Image image = new Image();
                image.Source = bitmap;
                image.Width = 200;
                image.Height = 200;
                image.Margin = new Thickness(0,20,0,0);
               
                Button button = new Button();
                button.Content = "Add";
                button.Width = 100;
                button.Height = 30;
                button.BorderThickness = new Thickness(1);
                button.VerticalAlignment = VerticalAlignment.Bottom;

                button.Background = Brushes.DarkGreen;
                button.Foreground = Brushes.White;
                button.Click += Button_Click;
              
                button.MouseEnter += (sender, e) =>
                {
                   
                    button.Foreground = Brushes.Black;
                    
                };

                button.MouseLeave += (sender, e) =>
                {
                    button.Background = Brushes.DarkGreen;
                    button.Foreground = Brushes.White;
                    
                };

                cardView.Children.Add(image); 
                cardView.Children.Add(label);
                cardView.Children.Add(button);
                
                double leftMargin = horizontalSpacing / 2;
                double rightMargin = horizontalSpacing / 2;

                if (i % cardsPerRow == 0) 
                {
                    leftMargin = horizontalSpacing / 4; 
                }
                else if (i % cardsPerRow == cardsPerRow - 1) 
                {
                    rightMargin = horizontalSpacing / 4; 
                }

                cardView.Margin = new Thickness(leftMargin, verticalSpacing / 2, rightMargin, verticalSpacing / 2);

                wrapPanel.Children.Add(cardView);
            }

            wrapPanel.Width = (cardWidth + horizontalSpacing) * cardsPerRow;

            MeinContainer.Content = wrapPanel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window popup = new Window();
            popup.Title = "Popup-Fenster";
            popup.Content = "Das ist ein Popup-Fenster!";
            popup.Width = 300;
            popup.Height = 350;
            popup.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            popup.ShowDialog();
        }
    }
}
