using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Color color = Color.FromRgb(0,0,0);
        double x = 0, y = 0, z = 0;
        double l = 0, a = 0, b = 0;
        double h = 0, hls_l = 0, s = 0;
        double R = 0, G = 0, B = 0;
        bool[] mode = { true, true, true, true, true, true, true };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void setXYZ()
        {
            x_slider.Value = x;
            x_textbox.Text = x.ToString();
            y_slider.Value = y;
            y_textbox.Text = y.ToString();
            z_slider.Value = z;
            z_textbox.Text = z.ToString();
        }

        private void setLAB()
        {
            l_slider.Value = l;
            l_textbox.Text = l.ToString();
            a_slider.Value = a;
            a_textbox.Text = a.ToString();
            b_slider.Value = b;
            b_textbox.Text = b.ToString();

        }

        private void setHLS()
        {
            h_slider.Value = h;
            h_textbox.Text = h.ToString();
            hls_l_slider.Value = hls_l;
            hls_l_textbox.Text = hls_l.ToString();
            s_slider.Value = s;
            s_textbox.Text = s.ToString();

        }
        //xyz -> lab
        private double func_xyz_lab(double x, double xw)
        {
            x /= xw;

            if (x > 0.008856)
                x = Math.Pow(x, 1.0 / 3);
            else
                x = 7.787 * x + 16.0 / 116;

            return x;
        }
        private void xyz_to_lab()
        {
            double l = 116 * func_xyz_lab(y, 100) - 16;
            double a = 500 * (func_xyz_lab(x, 95.047) - func_xyz_lab(y, 100));
            double b = 200 * (func_xyz_lab(y, 100) - func_xyz_lab(z, 108.883));

            this.l = l;
            this.a = a;
            this.b = b;
            setLAB();
        }

        //lab -> xyz
        private double func_lab_xyz(double x)
        {
            if (Math.Pow(x, 3) >= 0.008856)
                x = Math.Pow(x, 3);
            else
                x = (x - 16.0 / 116) / 7.787;

            return x;
        }
        private void lab_to_xyz()
        {
            double y = func_lab_xyz((l + 16) / 116) * 100;
            double x = func_lab_xyz(a / 500 + (l + 16) / 116) * 95.047;
            double z = func_lab_xyz((l + 16) / 116 - b / 200) * 108.883;

            this.x = x;
            this.y = y;
            this.z = z;
            setXYZ();
        }

        //xyz -> rgb

        private void xyz_to_rgb()
        {
            double[] comp = { x/ 100.0, y / 100.0, z/ 100.0 };

            double rn = 3.2406 * comp[0] - 1.5372 * comp[1] - 0.4986 * comp[2];
            double gn = -0.9689 * comp[0] + 1.8758 * comp[1] + 0.0415 * comp[2];
            double bn = 0.0557 * comp[0] - 0.2040 * comp[1] + 1.0570 * comp[2];

            double[] rgb = { rn, gn, bn };

            for (int i = 0; i < rgb.Length; i++)    
            {
                if (rgb[i] >= 0.0031308)
                    rgb[i] = 1.055 * Math.Pow(rgb[i], 1 / 2.4) - 0.055;
                else
                    rgb[i] *= 12.92;

                rgb[i] *= 255;

                if (rgb[i] < 0)
                {
                    rgb[i] = 0;
                    warning_textbox.Visibility = Visibility.Visible;
                }
                else if (rgb[i] > 255)
                {
                    rgb[i] = 255;
                    warning_textbox.Visibility = Visibility.Visible;
                }
                else
                    warning_textbox.Visibility = Visibility.Hidden;
            }

            R = rgb[0]; G = rgb[1]; B = rgb[2];
            //loggin.Text += Convert.ToByte(R) + ", " + Convert.ToByte(G) + ", " + Convert.ToByte(B);
            color = Color.FromRgb(Convert.ToByte(R), Convert.ToByte(G), Convert.ToByte(B));
            colorPicker.SelectedColor = color;
        }

        //rgb -> xyz 
        private void rgb_to_xyz()
        {
            double[] comp = { R / 255, G / 255, B / 255 };

            for (int i = 0; i < comp.Length; i++)
            {
                if (comp[i] >= 0.04045)
                    comp[i] = Math.Pow((comp[i] + 0.055) / 1.055, 2.4);
                else
                    comp[i] /= 12.92;

                comp[i] *= 100;
            }

            double x = 0.412453 * comp[0] + 0.357580 * comp[1] + 0.180423 * comp[2];
            double y = 0.212671 * comp[0] + 0.715160 * comp[1] + 0.072169 * comp[2];
            double z = 0.019334 * comp[0] + 0.119193 * comp[1] + 0.950227 * comp[2];

            this.x = x;
            this.y = y;
            this.z = z;

            setXYZ();

        }


        //xyz -> hls 
        private void xyz_to_hls()
        {
            xyz_to_rgb();
            double R = this.R / 255, G = this.G / 255, B = this.G / 255;
            double min = Math.Min(Math.Min(R, G), B);
            double max = Math.Max(Math.Max(R, G), B);
            double delta = max - min;

            double L = 100 * (max + min) / 2, H, S = 100;

            if (delta == 0)
            {
                H = 0;
                S = 0;
            }
            else
            {
                if (L < 50)
                    S *= (delta / (max + min));
                else
                    S *= delta / (2 - max - min);

                double hue;


                double del_R = (((max - R) / 6) + (delta / 2)) / delta;
                double del_G = (((max - G) / 6) + (delta / 2)) / delta;
                double del_B = (((max - B) / 6) + (delta / 2)) / delta;


                if (R == max)
                    hue = del_B - del_G;
                else if (G == max)
                    hue = (1.0 / 3) + del_R - del_B;
                else
                    hue = (2.0 / 3) + del_G - del_R;

                if (hue < 0)
                    hue += 1;
                if (hue > 1)
                    hue -= 1;

                H = hue * 360;
            }

            this.h = H;
            this.hls_l = L;
            this.s = S;
            setHLS();

        }

        //rgb -> hls
        private void rgb_to_hls()
        {
            double r = R / 255;
            double g = G / 255;
            double b = B / 255;

            double min = Math.Min(Math.Min(r, g), b);
            double max = Math.Max(Math.Max(r, g), b);
            double delta = max - min;

            double L = 100*(max + min) / 2, H, S = 100;


            if (delta == 0)
            {
                H = 0;
                S = 0;
            }
            else
            {
                if (L <= 50)
                    S *= (delta / (max + min));
                else
                    S *= delta / (2 - max - min);

                double hue;

                if (r == max)
                {
                    hue = ((g - b) / 6) / delta;
                }
                else if (g == max)
                {
                    hue = (1.0 / 3) + ((b - r) / 6) / delta;
                }
                else
                {
                    hue = (2.0 / 3) + ((r - g) / 6) / delta;
                }

                if (hue < 0)
                    hue += 1;
                if (hue > 1)
                    hue -= 1;

                H = hue * 360;
            }

            h = H;
            hls_l = L;
            s = S;
            setHLS();
        }

        //hls -> rgb
        private void hls_to_rgb()
        {
            double h = this.h, l = this.hls_l / 100.0, s = this.s / 100.0;

            double c = (1 - Math.Abs(2 * l - 1)) * s;
            double x = c * (1 - Math.Abs((h / 60) % 2 - 1));
            double m = l - c / 2.0;

            if (h >= 0 && h < 60)
            { 
                R = c; G = x; B = 0;
            }
            else if (h >= 60 && h < 120)
            { 
                R = x; G = c; B = 0; 
            }
            else if (h >= 120 && h < 180)
            {
                R = 0; G = c; B = x;
            }
            else if (h >= 180 && h < 240)
            {
                R = 0; G = x; B = c;
            }
            else if (h >=  240 && h < 300)
            {
                R = x; G = 0; B = c;
            }
            else
            {
                R = c; G = 0; B = x;
            }

            R = (R + m) * 255;
            G = (G + m) * 255;
            B = (B + m) * 255;

            //loggin.Text += Convert.ToByte(R) + ", " + Convert.ToByte(G) + ", " + Convert.ToByte(B);
            color = Color.FromRgb(Convert.ToByte(R), Convert.ToByte(G), Convert.ToByte(B));
            colorPicker.SelectedColor = color;
        }

        private void colorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (mode[0] == true)
            {
                for (int i = 0; i < mode.Length; i++)
                    mode[i] = false;

                //loggin.Text += "CHANGE color; ";

                color = (Color)colorPicker.SelectedColor;
                R = color.R; G = color.G; B = color.B;

                rgb_to_xyz();
                xyz_to_lab();
                rgb_to_hls();

                for (int i = 0; i < mode.Length; i++)
                    mode[i] = true;
            }
        }

        private void xyz_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (mode[1] ==  true)
            {
                for (int i = 0; i < mode.Length; i++)
                    mode[i] = false;

                Slider obj = sender as Slider;
                //loggin.Text += obj.Name.ToString();

                switch (obj.Name)
                {
                    case "x_slider":
                        x = x_slider.Value;
                        x_textbox.Text = x.ToString();
                        break;
                    case "y_slider":
                        y = y_slider.Value;
                        y_textbox.Text = y.ToString();
                        break;
                    case "z_slider":
                        z = z_slider.Value;
                        z_textbox.Text = z.ToString();
                        break;
                }

                xyz_to_rgb();
                rgb_to_hls();
                xyz_to_lab();

                for (int i = 0; i < mode.Length; i++)
                    mode[i] = true;
            }
        }

        private void lab_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (mode[2] == true)
            {
                for (int i = 0; i < mode.Length; i++)
                    mode[i] = false;

                Slider obj = sender as Slider;
                //loggin.Text += obj.Name.ToString();

                switch (obj.Name)
                {
                    case "l_slider":
                        l = l_slider.Value;
                        l_textbox.Text = l.ToString();
                        break;
                    case "a_slider":
                        a = a_slider.Value;
                        a_textbox.Text = a.ToString();
                        break;
                    case "b_slider":
                        b = b_slider.Value;
                        b_textbox.Text = b.ToString();
                        break;
                }

                lab_to_xyz();
                xyz_to_hls();

                for (int i = 0; i < mode.Length; i++)
                    mode[i] = true;
            }
        }

        private void hls_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (mode[3] == true)
            {
                for (int i = 0; i < mode.Length; i++)
                    mode[i] = false;

                Slider obj = sender as Slider;
                //loggin.Text += obj.Name.ToString();

                switch (obj.Name)
                {
                    case "h_slider":
                        h = h_slider.Value;
                        h_textbox.Text = h.ToString();
                        break;
                    case "hls_l_slider":
                        hls_l = hls_l_slider.Value;
                        hls_l_textbox.Text = hls_l.ToString();
                        break;
                    case "s_slider":
                        s = s_slider.Value;
                        s_textbox.Text = s.ToString();
                        break;
                }

                hls_to_rgb();
                rgb_to_xyz();
                xyz_to_lab();

                for (int i = 0; i < mode.Length; i++)
                    mode[i] = true;
            }

        }


        private void xyz_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mode[4] == true)
            {
                for (int i = 0; i < mode.Length; i++)
                    mode[i] = false;

                TextBox obj = sender as TextBox;
                bool work = false;
                //loggin.Text += obj.Name.ToString();

                switch (obj.Name)
                {
                    case "x_textbox":
                        if (Double.TryParse(x_textbox.Text, out x))
                        {
                            x_slider.Value = x;
                            work = true;
                        }
                        break;
                    case "y_textbox":
                        if (Double.TryParse(y_textbox.Text, out y))
                        {
                            y_slider.Value = y;
                            work = true;
                        }
                        break;
                    case "z_textbox":
                        if (Double.TryParse(z_textbox.Text, out z))
                        {
                            z_slider.Value = z;
                            work = true;
                        }
                        break;
                }
                
                if (work)
                {
                    xyz_to_rgb();
                    rgb_to_hls();
                    xyz_to_lab();
                }

                for (int i = 0; i < mode.Length; i++)
                    mode[i] = true;
            }
        }

        private void lab_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mode[5] == true)
            {
                for (int i = 0; i < mode.Length; i++)
                    mode[i] = false;

                TextBox obj = sender as TextBox;
                //loggin.Text += obj.Name.ToString();
                bool work = false;

                switch (obj.Name)
                {
                    case "l_textbox":
                        if (Double.TryParse(l_textbox.Text, out l))
                        {
                            l_slider.Value = l;
                            work = true;
                        }
                        break;
                    case "a_textbox":
                        if (Double.TryParse(a_textbox.Text, out a))
                        {
                            a_slider.Value = a;
                            work = true;
                        }
                        break;
                    case "b_textbox":
                        if (Double.TryParse(b_textbox.Text, out b))
                        {
                            b_slider.Value = b;
                            work = true;
                        }
                        break;
                }

                if (work)
                {
                    lab_to_xyz();
                    xyz_to_hls();
                }

                for (int i = 0; i < mode.Length; i++)
                    mode[i] = true;
            }
        }

        private void hls_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mode[6] == true)
            {
                for (int i = 0; i < mode.Length; i++)
                    mode[i] = false;

                TextBox obj = sender as TextBox;
                //loggin.Text += obj.Name.ToString();
                bool work = true;

                switch (obj.Name)
                {
                    case "h_textbox":
                        if (Double.TryParse(h_textbox.Text, out h))
                        {
                            h_slider.Value = h;
                            work = true;
                        }
                        break;
                    case "hls_l_textbox":
                        if (Double.TryParse(hls_l_textbox.Text, out hls_l))
                        {
                            hls_l_slider.Value = hls_l;
                            work = true;
                        }
                        break;
                    case "s_textbox":
                        if (Double.TryParse(s_textbox.Text, out s))
                        {
                            s_slider.Value = s;
                            work = true;
                        }
                        break;
                }

                if (work)
                {
                    hls_to_rgb();
                    rgb_to_xyz();
                    xyz_to_lab();
                }


                for (int i = 0; i < mode.Length; i++)
                    mode[i] = true;
            }
        }

    }
}
