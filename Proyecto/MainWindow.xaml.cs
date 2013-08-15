//------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.ControlsBasics
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using Microsoft.Kinect;
    using Microsoft.Kinect.Toolkit;
    using Microsoft.Kinect.Toolkit.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Controls;
    
    

    
    

    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>
    public partial class MainWindow
    {
        
        public static readonly DependencyProperty PageLeftEnabledProperty = DependencyProperty.Register(
            "PageLeftEnabled", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));

        public static readonly DependencyProperty PageRightEnabledProperty = DependencyProperty.Register(
            "PageRightEnabled", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));

        private const double ScrollErrorMargin = 0.001;

        private const int PixelScrollByAmount = 20;

        public  KinectSensorChooser sensorChooser;

        public static MainWindow m1;

        public string texto;

        public static int sumatotal1 = 0;

        public string texto2;

        public List<string> guardatexto = new List<string>();

        public List<string> guardasuma = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class. 
        /// </summary>
        /// 
    
        public MainWindow()
        {
            this.InitializeComponent();
            
           
            
            // initialize the sensor chooser and UI
            
            MainWindow.m1 = this;
            m1.textBox3.Text = "0";
            
          
            
                this.sensorChooser = new KinectSensorChooser();
                this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
                this.sensorChooserUi.KinectSensorChooser = this.sensorChooser;
                this.sensorChooser.Start();
            

            // Bind the sensor chooser's current sensor to the KinectRegion
            var regionSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.kinectRegion, KinectRegion.KinectSensorProperty, regionSensorBinding);

            // Clear out placeholder content
            this.wrapPanel.Children.Clear();

            
           
            for (var index = 0; index < 7; ++index)
            {
                if (index == 0)
                {
                    var button = new KinectTileButton { Label = ("Bebida").ToString(CultureInfo.CurrentCulture), FontSize = 23};
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bebida0.png"));
                    button.Content = img;
                    this.wrapPanel.Children.Add(button);
                }


                if (index == 1)
                {
                    var button = new KinectTileButton { Label = ("Papas Fritas").ToString(CultureInfo.CurrentCulture), FontSize = 23 };
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/papas0.png"));
                    button.Content = img;
                    this.wrapPanel.Children.Add(button);
                    
                }
                if (index == 2)
                {
                    var button = new KinectTileButton { Label = ("Hamburguesa").ToString(CultureInfo.CurrentCulture), FontSize = 23 };
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/hambur2.png"));
                    button.Content = img;
                    this.wrapPanel.Children.Add(button);
                    
                }
                if (index == 3)
                {
                    var button = new KinectTileButton { Label = ("Empanaditas").ToString(CultureInfo.CurrentCulture), FontSize = 23 };
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/empanaditas0.png"));
                    button.Content = img;
                    this.wrapPanel.Children.Add(button);
                   
                }
                if (index == 4)
                {
                    var button = new KinectTileButton { Label = ("Cajita feliz   $1990").ToString(CultureInfo.CurrentCulture), FontSize = 23 };
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/cajita0.png"));
                    button.Content = img;
                    this.wrapPanel.Children.Add(button);
                    
                }
                if (index == 5)
                {
                    var button = new KinectTileButton { Label = ("Completos").ToString(CultureInfo.CurrentCulture),FontSize = 23 };
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/completos0.png"));
                    button.Content = img;
                    this.wrapPanel.Children.Add(button);
                    
                }
                if (index == 6)
                {
                    var button = new KinectTileButton { Label = ("Helados     $490").ToString(CultureInfo.CurrentCulture),FontSize = 23 };
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/helados0.png"));
                    button.Content = img;
                    this.wrapPanel.Children.Add(button);
                    
                }
            }

            
            
            // Bind listner to scrollviwer scroll position change, and check scroll viewer position
            this.UpdatePagingButtonState();
            scrollViewer.ScrollChanged += (o, e) => this.UpdatePagingButtonState();

        }
       
        /// <summary>
        /// CLR Property Wrappers for PageLeftEnabledProperty
        /// </summary>
        public bool PageLeftEnabled
        {
            get
            {
                return (bool)GetValue(PageLeftEnabledProperty);
            }

            set
            {
                this.SetValue(PageLeftEnabledProperty, value);
            }
        }
        public void menuprincipal()
        {
            this.wrapPanel.Children.Clear();

            MainWindow.m1.kinectCircleButton1.Visibility = Visibility.Hidden;

            for (var index = 0; index < 7; ++index)
            {
                if (index == 0)
                {
                    var button = new KinectTileButton { Label = ("Bebida").ToString(CultureInfo.CurrentCulture), FontSize = 23 };
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bebida0.png"));
                    button.Content = img;
                    this.wrapPanel.Children.Add(button);
                }


                if (index == 1)
                {
                    var button = new KinectTileButton { Label = ("Papas Fritas").ToString(CultureInfo.CurrentCulture), FontSize = 23 };
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/papas0.png"));
                    button.Content = img;
                    this.wrapPanel.Children.Add(button);

                }
                if (index == 2)
                {
                    var button = new KinectTileButton { Label = ("Hamburguesa").ToString(CultureInfo.CurrentCulture), FontSize = 23 };
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/hambur2.png"));
                    button.Content = img;
                    this.wrapPanel.Children.Add(button);

                }
                if (index == 3)
                {
                    var button = new KinectTileButton { Label = ("Empanaditas").ToString(CultureInfo.CurrentCulture), FontSize = 23 };
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/empanaditas0.png"));
                    button.Content = img;
                    this.wrapPanel.Children.Add(button);

                }
                if (index == 4)
                {
                    var button = new KinectTileButton { Label = ("Cajita feliz   $1990").ToString(CultureInfo.CurrentCulture), FontSize = 23 };
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/cajita0.png"));
                    button.Content = img;
                    this.wrapPanel.Children.Add(button);

                }
                if (index == 5)
                {
                    var button = new KinectTileButton { Label = ("Completos").ToString(CultureInfo.CurrentCulture), FontSize = 23 };
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/completos0.png"));
                    button.Content = img;
                    this.wrapPanel.Children.Add(button);

                }
                if (index == 6)
                {
                    var button = new KinectTileButton { Label = ("Helados     $490").ToString(CultureInfo.CurrentCulture), FontSize = 23 };
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/helados0.png"));
                    button.Content = img;
                    this.wrapPanel.Children.Add(button);

                }
            }
        }

        /// <summary>
        /// CLR Property Wrappers for PageRightEnabledProperty
        /// </summary>
        public bool PageRightEnabled
        {
            get
            {
                return (bool)GetValue(PageRightEnabledProperty);
            }

            set
            {
                this.SetValue(PageRightEnabledProperty, value);
            }
        }

        /// <summary>
        /// Called when the KinectSensorChooser gets a new sensor
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="args">event arguments</param>
        private static void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
        {
            if (args.OldSensor != null)
            {
                try
                {
                    args.OldSensor.DepthStream.Range = DepthRange.Default;
                    args.OldSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    args.OldSensor.DepthStream.Disable();
                    args.OldSensor.SkeletonStream.Disable();
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }

            if (args.NewSensor != null)
            {
                try
                {
                    args.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    args.NewSensor.SkeletonStream.Enable();

                    try
                    {
                        args.NewSensor.DepthStream.Range = DepthRange.Near;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;
                    }
                    catch (InvalidOperationException)
                    {
                        // Non Kinect for Windows devices do not support Near mode, so reset back to default mode.
                        args.NewSensor.DepthStream.Range = DepthRange.Default;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    }
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }
        }

        /// <summary>
        /// Execute shutdown tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.sensorChooser.Stop();
        }

        /// <summary>
        /// Handle a button click from the wrap panel.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>



        private void KinectTileButtonClick(object sender, RoutedEventArgs e)
        {

            var button = (KinectTileButton)e.OriginalSource;
            MainWindow.m1.textBox1.SelectionStart = MainWindow.m1.textBox1.Text.Length;
            MainWindow.m1.textBox1.ScrollToEnd();

            if (MainWindow.m1.textBox3.Text == "1")
                sumatotal1 = 0;

            MainWindow.m1.textBox3.Text = "0";

            texto = button.Label.ToString();
            this.wrapPanel.Children.Clear();

            if (MainWindow.m1.texto == "Bebida")
            {
                MainWindow.m1.kinectCircleButton1.Visibility = Visibility.Visible;
                for (var index = 0; index < 7; ++index)
                {
                    if (index == 0)
                    {
                        var button1 = new KinectTileButton { Label = ("Chica    $490").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bebida2.0.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                    if (index == 2)
                    {
                        var button1 = new KinectTileButton { Label = ("Mediana    $590").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bebida2.1.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                    if (index == 1)
                    {
                        var button1 = new KinectTileButton { Label = ("Grande    $650").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bebida2.2.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }

                }
            }
            else if (MainWindow.m1.texto == "Helados     $490")
            {
                MainWindow.m1.kinectCircleButton1.Visibility = Visibility.Visible;
                for (var index = 0; index < 7; ++index)
                {
                    if (index == 0)
                    {
                        var button1 = new KinectTileButton { Label = ("Chocolate").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/helados1.2.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);


                    }
                    if (index == 2)
                    {
                        var button1 = new KinectTileButton { Label = ("Vainilla").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/helados1.0.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                    if (index == 1)
                    {
                        var button1 = new KinectTileButton { Label = ("Vainilla/Chocolate").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/helados1.1.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                    if (index == 3)
                    {
                        var button1 = new KinectTileButton { Label = ("Frutilla").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/helados1.3.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }

                }
            }
            else if (MainWindow.m1.texto == "Empanaditas")
            {
                MainWindow.m1.kinectCircleButton1.Visibility = Visibility.Visible;
                for (var index = 0; index < 7; ++index)
                {
                    if (index == 0)
                    {
                        var button1 = new KinectTileButton { Label = ("3 Unidades   $490").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/empanaditas1.1.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);
                    }
                    if (index == 2)
                    {
                        var button1 = new KinectTileButton { Label = ("6 Unidades   $890").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/empanaditas1.1.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                    if (index == 1)
                    {
                        var button1 = new KinectTileButton { Label = ("9 Unidades   $1250").ToString(CultureInfo.CurrentCulture), FontSize = 23 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/empanaditas1.0.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                    if (index == 3)
                    {
                        var button1 = new KinectTileButton { Label = ("12 Unidades   $1590").ToString(CultureInfo.CurrentCulture), FontSize = 22 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/empanaditas1.0.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                }

            }
            else if (MainWindow.m1.texto == "Completos")
            {
                MainWindow.m1.kinectCircleButton1.Visibility = Visibility.Visible;
                for (var index = 0; index < 4; ++index)
                {
                    if (index == 0)
                    {
                        var button1 = new KinectTileButton { Label = ("16 cms.    $490").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/completos1.0.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);


                    }
                    if (index == 2)
                    {
                        var button1 = new KinectTileButton { Label = ("20 cms.    $650").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/completos1.1.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                    if (index == 1)
                    {
                        var button1 = new KinectTileButton { Label = ("24 cms.    $790").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/completos1.2.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                    if (index == 3)
                    {
                        var button1 = new KinectTileButton { Label = ("30 cms.    $990").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/completos1.3.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }

                }
            }
            else if (MainWindow.m1.texto == "Cajita feliz   $1990")
            {
                MainWindow.m1.kinectCircleButton1.Visibility = Visibility.Visible;
                for (var index = 0; index < 4; ++index)
                {
                    if (index == 0)
                    {
                        var button1 = new KinectTileButton { Label = ("Juguete 1").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/cajita1.0.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);


                    }
                    if (index == 2)
                    {
                        var button1 = new KinectTileButton { Label = ("Juguete 2").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/cajita1.1.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                    if (index == 1)
                    {
                        var button1 = new KinectTileButton { Label = ("Juguete 3").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/cajita1.2.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                    if (index == 3)
                    {
                        var button1 = new KinectTileButton { Label = ("Juguete 4").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/cajita1.3.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                }
            }
            else if (MainWindow.m1.texto == "Hamburguesa")
            {
                MainWindow.m1.kinectCircleButton1.Visibility = Visibility.Visible;
                for (var index = 0; index < 5; ++index)
                {
                    if (index == 0)
                    {
                        var button1 = new KinectTileButton { Label = ("Con Queso   $990").ToString(CultureInfo.CurrentCulture), FontSize = 21 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/hambur1.0.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);


                    }
                    if (index == 2)
                    {
                        var button1 = new KinectTileButton { Label = ("Doble con Queso  $1990").ToString(CultureInfo.CurrentCulture), FontSize = 18 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/hambur1.1.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                    if (index == 4)
                    {
                        var button1 = new KinectTileButton { Label = ("Cuadruple con Queso  $3490").ToString(CultureInfo.CurrentCulture), FontSize = 15 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/hambur1.2.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                    if (index == 1)
                    {
                        var button1 = new KinectTileButton { Label = ("Italiana    $1190").ToString(CultureInfo.CurrentCulture), FontSize = 21 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/hambur1.3.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                    if (index == 3)
                    {
                        
                        
                        var button1 = new KinectTileButton { Label = ("Monster    $3990").ToString(CultureInfo.CurrentCulture), FontSize = 21 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/hambur1.4.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                }
            }
            else if (MainWindow.m1.texto == "Papas Fritas")
            {
                MainWindow.m1.kinectCircleButton1.Visibility = Visibility.Visible;
                for (var index = 0; index < 3; ++index)
                {
                    if (index == 0)
                    {
                        var button1 = new KinectTileButton { Label = ("Chicas      $490").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/papas1.0.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);


                    }
                    if (index == 2)
                    {
                        var button1 = new KinectTileButton { Label = ("Medianas    $590").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/papas1.1.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                    if (index == 1)
                    {
                        var button1 = new KinectTileButton { Label = ("Grandes    $790").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/papas1.2.png"));
                        button1.Content = img;
                        this.wrapPanel.Children.Add(button1);

                    }
                }
            }

            texto2 = button.Label.ToString();
            if (texto2 == "Chica    $490")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Bebida Chica";
                sumatotal1 = 490 + sumatotal1;
                String s = Convert.ToString(sumatotal1);
                MainWindow.m1.textBox2.Text = s;
                guardasuma.Add(s);

            }
            if (texto2 == "Mediana    $590")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Bebida Mediana";
                sumatotal1 = 590 + sumatotal1;
                String s = Convert.ToString(sumatotal1);
                MainWindow.m1.textBox2.Text = s;
                guardasuma.Add(s);


            }
            if (texto2 == "Grande    $650")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Bebida Grande";
                sumatotal1 = 650 + sumatotal1;
                String s = Convert.ToString(sumatotal1);
                MainWindow.m1.textBox2.Text = s;
                guardasuma.Add(s);


            }


            if (MainWindow.m1.texto == "Chica    $490" || MainWindow.m1.texto == "Grande    $650" || MainWindow.m1.texto == "Mediana    $590")
            {
                MainWindow.m1.kinectCircleButton1.Visibility = Visibility.Hidden;
                for (var index = 0; index < 4; ++index)
                {
                    if (index == 0)
                    {
                        var button3 = new KinectTileButton { Label = ("Fanta").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bebida1.2.png"));
                        button3.Content = img;
                        this.wrapPanel.Children.Add(button3);

                    }
                    if (index == 1)
                    {
                        var button3 = new KinectTileButton { Label = ("Coca-Cola").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bebida1.0.png"));
                        button3.Content = img;
                        this.wrapPanel.Children.Add(button3);


                    }
                    if (index == 2)
                    {
                        var button3 = new KinectTileButton { Label = ("Sprite").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bebida1.3.png"));
                        button3.Content = img;
                        this.wrapPanel.Children.Add(button3);

                    }
                    if (index == 3)
                    {
                        var button3 = new KinectTileButton { Label = ("Pepsi").ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bebida1.1.png"));
                        button3.Content = img;
                        this.wrapPanel.Children.Add(button3);
                    }

                }

            }

            if (button.Label as string == "Fanta")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + " Fanta" + "\n";
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                menuprincipal();

            }
            if (button.Label as string == "Coca-Cola")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + " Coca-Cola" + "\n";
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                menuprincipal();
            }
            if (button.Label as string == "Sprite")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + " Sprite" + "\n";
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                menuprincipal();
            }
            if (button.Label as string == "Pepsi")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + " Pepsi" + "\n";
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                menuprincipal();
            }

            if (button.Label as string == "Chocolate")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Helado de Chocolate" + "\n";
                sumatotal1 = 490 + sumatotal1;
                String s = Convert.ToString(sumatotal1);
                MainWindow.m1.textBox2.Text = s;
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                guardasuma.Add(s);
                menuprincipal();

            }

            if (button.Label as string == "Vainilla")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Helado de Vainilla" + "\n";
                sumatotal1 = 490 + sumatotal1;
                String s = Convert.ToString(sumatotal1);
                MainWindow.m1.textBox2.Text = s;
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                guardasuma.Add(s);
                menuprincipal();
            }
            if (button.Label as string == "Vainilla/Chocolate")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Helado de Vainilla y Chocolate" + "\n";
                sumatotal1 = 490 + sumatotal1;
                String s = Convert.ToString(sumatotal1);
                MainWindow.m1.textBox2.Text = s;
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                guardasuma.Add(s);
                menuprincipal();
            }
            if (button.Label as string == "Frutilla")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Helado de Frutilla" + "\n";
                sumatotal1 = 490 + sumatotal1;
                String s = Convert.ToString(sumatotal1);
                MainWindow.m1.textBox2.Text = s;
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                guardasuma.Add(s);
                menuprincipal();
            }

            if (button.Label as string == "3 Unidades   $490")
            {

                sumatotal1 = 490 + sumatotal1;
                String s = Convert.ToString(sumatotal1);
                MainWindow.m1.textBox2.Text = s;
                guardasuma.Add(s);

            }

            if (button.Label as string == "6 Unidades   $890")
            {

                sumatotal1 = 890 + sumatotal1;
                String s = Convert.ToString(sumatotal1);
                MainWindow.m1.textBox2.Text = s;
                guardasuma.Add(s);

            }

            if (button.Label as string == "9 Unidades   $1250")
            {

                sumatotal1 = 1250 + sumatotal1;
                String s = Convert.ToString(sumatotal1);
                MainWindow.m1.textBox2.Text = s;
                guardasuma.Add(s);

            }
            if (button.Label as string == "12 Unidades   $1590")
            {
                
                sumatotal1 = 1590 + sumatotal1;
                String s = Convert.ToString(sumatotal1);
                MainWindow.m1.textBox2.Text = s;
                guardasuma.Add(s);

            }
            texto2 = button.Label.ToString();
            if (MainWindow.m1.texto2 == "3 Unidades   $490" || MainWindow.m1.texto2 == "6 Unidades   $890" || MainWindow.m1.texto2 == "9 Unidades   $1250" || MainWindow.m1.texto2 == "12 Unidades   $1590")
            {
                MainWindow.m1.kinectCircleButton1.Visibility = Visibility.Hidden;
                for (var index = 0; index < 3; ++index)
                {
                    if (index == 0)
                    {
                        var button3 = new KinectTileButton { Label = ("Queso " + MainWindow.m1.texto2).ToString(CultureInfo.CurrentCulture), FontSize = 18 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/empanaditas2.1.png"));
                        button3.Content = img;
                        this.wrapPanel.Children.Add(button3);


                    }
                    if (index == 1)
                    {
                        var button3 = new KinectTileButton { Label = ("Jamón/Queso " + MainWindow.m1.texto2).ToString(CultureInfo.CurrentCulture), FontSize = 17 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/empanaditas2.1.png"));
                        button3.Content = img;
                        this.wrapPanel.Children.Add(button3);

                    }

                }
            }
            if (button.Label as string == "Queso 3 Unidades   $490")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Empanaditas de Queso 3 Unidades" + "\n";
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                menuprincipal();
            }
            if (button.Label as string == "Queso 6 Unidades   $890")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Empanaditas de Queso 6 Unidades" + "\n";
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                menuprincipal();
            }
            if (button.Label as string == "Queso 9 Unidades   $1250")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Empanaditas de Queso 9 Unidades" + "\n";
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                menuprincipal();
            }
            if (button.Label as string == "Queso 12 Unidades   $1590")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Empanaditas de Queso 12 Unidades" + "\n";
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                menuprincipal();
            }

            if (button.Label as string == "Jamón/Queso 3 Unidades   $490")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Empanaditas de Jamón/Queso 3 Unidades" + "\n";
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                menuprincipal();
            }
            if (button.Label as string == "Jamón/Queso 6 Unidades   $890")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Empanaditas de Jamón/Queso 6 Unidades" + "\n";
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                menuprincipal();
            }
            if (button.Label as string == "Jamón/Queso 9 Unidades   $1250")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Empanaditas de Jamón/Queso 9 Unidades" + "\n";
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                menuprincipal();
            }
            if (button.Label as string == "Jamón/Queso 12 Unidades   $1590")
            {
                MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Empanaditas de Jamón/Queso 12 Unidades" + "\n";
                guardatexto.Add(MainWindow.m1.textBox1.Text);
                menuprincipal();
            }

            if (button.Label as string == "16 cms.    $490")
            {

                sumatotal1 = 490 + sumatotal1;
                String s = Convert.ToString(sumatotal1);
                MainWindow.m1.textBox2.Text = s;
                guardasuma.Add(s);

            }
            if (button.Label as string == "20 cms.    $650")
            {

                sumatotal1 = 650 + sumatotal1;
                String s = Convert.ToString(sumatotal1);
                MainWindow.m1.textBox2.Text = s;
                guardasuma.Add(s);

            }
            if (button.Label as string == "24 cms.    $790")
            {

                sumatotal1 = 790 + sumatotal1;
                String s = Convert.ToString(sumatotal1);
                MainWindow.m1.textBox2.Text = s;
                guardasuma.Add(s);

            }
            if (button.Label as string == "30 cms.    $990")
            {

                sumatotal1 = 990 + sumatotal1;
                String s = Convert.ToString(sumatotal1);
                MainWindow.m1.textBox2.Text = s;
                guardasuma.Add(s);

            }
            if (MainWindow.m1.texto2 == "16 cms.    $490" || MainWindow.m1.texto2 == "20 cms.    $650" || MainWindow.m1.texto2 == "24 cms.    $790" || MainWindow.m1.texto2 == "30 cms.    $990")
            {
                MainWindow.m1.kinectCircleButton1.Visibility = Visibility.Hidden;
                for (var index = 0; index < 4; ++index)
                {
                    if (index == 0)
                    {
                        var button3 = new KinectTileButton { Label = ("Completo de " + MainWindow.m1.texto2).ToString(CultureInfo.CurrentCulture), FontSize = 21 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/completos2.0.png"));
                        button3.Content = img;
                        this.wrapPanel.Children.Add(button3);


                    }
                    if (index == 1)
                    {
                        var button3 = new KinectTileButton { Label = ("Italiano de " + MainWindow.m1.texto2).ToString(CultureInfo.CurrentCulture), FontSize = 24 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/completos2.1.png"));
                        button3.Content = img;
                        this.wrapPanel.Children.Add(button3);
                        

                    }
                    if (index == 2)
                    {
                        var button3 = new KinectTileButton { Label = ("Vienesa Mayo de " + MainWindow.m1.texto2).ToString(CultureInfo.CurrentCulture), FontSize = 18 };
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/completos2.2.png"));
                        button3.Content = img;
                        this.wrapPanel.Children.Add(button3);
                        

                    }

                }
            }

                if (button.Label as string == "Completo de 16 cms.    $490")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Completo de 16 cms." + "\n";
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    menuprincipal();
                }
                if (button.Label as string == "Completo de 20 cms.    $650")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Completo de 20 cms." + "\n";
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    menuprincipal();
                }
                if (button.Label as string == "Completo de 24 cms.    $790")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Completo de 24 cms." + "\n";
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    menuprincipal();
                }
                if (button.Label as string == "Completo de 30 cms.    $990")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Completo de 30 cms." + "\n";
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    menuprincipal();
                }


                if (button.Label as string == "Italiano de 16 cms.    $490")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Italiano de 16 cms." + "\n";
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    menuprincipal();
                }
                if (button.Label as string == "Italiano de 20 cms.    $650")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Italiano de 20 cms." + "\n";
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    menuprincipal();
                }
                if (button.Label as string == "Italiano de 24 cms.    $790")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Italiano de 24 cms." + "\n";
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    menuprincipal();
                }
                if (button.Label as string == "Italiano de 30 cms.    $990")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Italiano de 30 cms." + "\n";
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    menuprincipal();
                }
                if (button.Label as string == "Vienesa Mayo de 16 cms.    $490")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Vienesa Mayo de 16 cms." + "\n";
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    menuprincipal();
                }
                if (button.Label as string == "Vienesa Mayo de 20 cms.    $650")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Vienesa Mayo de 20 cms." + "\n";
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    menuprincipal();
                }
                if (button.Label as string == "Vienesa Mayo de 24 cms.    $790")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Vienesa Mayo de 24 cms." + "\n";
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    menuprincipal();
                }
                if (button.Label as string == "Vienesa Mayo de 30 cms.    $990")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Vienesa Mayo de 30 cms." + "\n";
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    menuprincipal();
                }


                
                if (button.Label as string == "Juguete 1")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Cajita Feliz con Juguete 1" + "\n";
                    sumatotal1 = 1990 + sumatotal1;
                    String s = Convert.ToString(sumatotal1);
                    MainWindow.m1.textBox2.Text = s;
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    guardasuma.Add(s);
                    menuprincipal();
                }
                if (button.Label as string == "Juguete 2")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Cajita Feliz con Juguete 2" + "\n";
                    sumatotal1 = 1990 + sumatotal1;
                    String s = Convert.ToString(sumatotal1);
                    MainWindow.m1.textBox2.Text = s;
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    guardasuma.Add(s);
                    menuprincipal();
                }
                if (button.Label as string == "Juguete 3")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Cajita Feliz con Juguete 3" + "\n";
                    sumatotal1 = 1990 + sumatotal1;
                    String s = Convert.ToString(sumatotal1);
                    MainWindow.m1.textBox2.Text = s;
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    guardasuma.Add(s);

                    menuprincipal();
                }
                if (button.Label as string == "Juguete 4")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Cajita Feliz con Juguete 4" + "\n";
                    sumatotal1 = 1990 + sumatotal1;
                    String s = Convert.ToString(sumatotal1);
                    MainWindow.m1.textBox2.Text = s;
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    guardasuma.Add(s);
                    menuprincipal();
                }
                if (button.Label as string == "Con Queso   $990")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Hamburguesa con Queso" + "\n";
                    sumatotal1 = 990 + sumatotal1;
                    String s = Convert.ToString(sumatotal1);
                    MainWindow.m1.textBox2.Text = s;
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    guardasuma.Add(s);
                    menuprincipal();
                }
                if (button.Label as string == "Doble con Queso  $1990")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Hamburguesa Doble con Queso" + "\n";
                    sumatotal1 = 1990 + sumatotal1;
                    String s = Convert.ToString(sumatotal1);
                    MainWindow.m1.textBox2.Text = s;
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    guardasuma.Add(s);
                    menuprincipal();
                }
                if (button.Label as string == "Cuadruple con Queso  $3490")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Hamburguesa Cuadruple con Queso" + "\n";
                    sumatotal1 = 3490 + sumatotal1;
                    String s = Convert.ToString(sumatotal1);
                    MainWindow.m1.textBox2.Text = s;
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    guardasuma.Add(s);
                    menuprincipal();
                }
                if (button.Label as string == "Italiana    $1190")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Hamburguesa Italiana" + "\n";
                    sumatotal1 = 1190 + sumatotal1;
                    String s = Convert.ToString(sumatotal1);
                    MainWindow.m1.textBox2.Text = s;
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    guardasuma.Add(s);
                    menuprincipal();
                }
                if (button.Label as string == "Monster    $3990")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Hamburguesa Monster" + "\n";
                    sumatotal1 = 3990 + sumatotal1;
                    String s = Convert.ToString(sumatotal1);
                    MainWindow.m1.textBox2.Text = s;
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    guardasuma.Add(s);
                    menuprincipal();
                }
                if (button.Label as string == "Chicas      $490")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Papas Fritas Chicas" + "\n";
                    sumatotal1 = 490 + sumatotal1;
                    String s = Convert.ToString(sumatotal1);
                    MainWindow.m1.textBox2.Text = s;
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    guardasuma.Add(s);
                    menuprincipal();
                }
                if (button.Label as string == "Medianas    $590")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Papas Fritas Medianas" + "\n";
                    sumatotal1 = 590 + sumatotal1;
                    String s = Convert.ToString(sumatotal1);
                    MainWindow.m1.textBox2.Text = s;
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    guardasuma.Add(s);
                    menuprincipal();
                }
                if (button.Label as string == "Grandes    $790")
                {
                    MainWindow.m1.textBox1.Text = MainWindow.m1.textBox1.Text + "Papas Fritas Grandes" + "\n";
                    sumatotal1 = 790 + sumatotal1;
                    String s = Convert.ToString(sumatotal1);
                    MainWindow.m1.textBox2.Text = s;
                    guardatexto.Add(MainWindow.m1.textBox1.Text);
                    guardasuma.Add(s);
                    menuprincipal();
                }







            }
        
                
               /// <summary>
        /// Handle paging right (next button).
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void PageRightButtonClick(object sender, RoutedEventArgs e)
        {
            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + PixelScrollByAmount);
        }

        /// <summary>
        /// Handle paging left (previous button).
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void PageLeftButtonClick(object sender, RoutedEventArgs e)
        {
            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - PixelScrollByAmount);
        }

        /// <summary>
        /// Change button state depending on scroll viewer position
        /// </summary>
        private void UpdatePagingButtonState()
        {
            this.PageLeftEnabled = scrollViewer.HorizontalOffset > ScrollErrorMargin;
            this.PageRightEnabled = scrollViewer.HorizontalOffset < scrollViewer.ScrollableWidth - ScrollErrorMargin;
        }

       

        private void kinectCircleButton2_Click(object sender, RoutedEventArgs e)
        {
           
                var button = (KinectCircleButton)e.OriginalSource;
                var selectionDisplay = new SelectionDisplay(button.Label as string);
                this.kinectRegionGrid.Children.Add(selectionDisplay);
                e.Handled = true;
                textBox1.Clear();
                textBox2.Clear();
                m1.textBox3.Text = "1";
                menuprincipal();
            

            
        }   

        private void kinectCircleButton3_Click(object sender, RoutedEventArgs e)
        {
            guardasuma.Clear();
            guardatexto.Clear();
            textBox1.Clear();
            textBox2.Clear();
            m1.textBox3.Text = "1";
     
        }

        private void KinectTileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void kinectCircleButton1_Click(object sender, RoutedEventArgs e)
        {
            menuprincipal();
        }

        private void kinectCircleButton4_Click(object sender, RoutedEventArgs e)
        {
            if(guardasuma==null){}
            else if (guardasuma.Count == 1)
            {
                guardasuma.Clear();
                guardatexto.Clear();
                textBox1.Clear();
                textBox2.Clear();
                m1.textBox3.Text = "1";
            }
            else if(guardatexto.Count > 1)
            {

                MainWindow.m1.textBox1.Text=guardatexto[guardatexto.Count-2];
                MainWindow.m1.textBox2.Text=guardasuma[guardasuma.Count-2];
                guardasuma.RemoveAt(guardasuma.Count-1);
                guardatexto.RemoveAt(guardatexto.Count-1);
            }

        }





        
    }
}
