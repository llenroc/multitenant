﻿using Microsoft.IdentityModel.Clients.ActiveDirectory;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private AuthenticationContext authContext = null;
        private const string authority = "https://login.windows.net/common";
        private const string resourceId = "https://graph.windows.net/";
        //private const string resourceId = "36bda7c5-cc23-4618-9e09-e710b2357818";
        private const string clientId = "e54b04c6-6e2b-45e8-98eb-78b5616276d2";
        private const string redirectUri = "http://testauthwpf";

        public MainWindow()
        {
            InitializeComponent();

            // see if the user is already logged in
            authContext = new AuthenticationContext(authority, new FileCache());
            try
            {
                AuthenticationResult result = authContext.AcquireToken(resourceId, clientId, new Uri(redirectUri), PromptBehavior.Never);
                message.Content = "logged in";
            }
            catch (AdalException)
            {
                // no need to raise an error
            }

        }

        private void login_Click(object sender, RoutedEventArgs e)
        {

            popuplogin.IsOpen = true;

            // login the user
            //try
            //{
            //    AuthenticationResult result = authContext.AcquireToken(resourceId, clientId, new Uri(redirectUri), PromptBehavior.Always);
            //    message.Content = "logged in";
            //}
            //catch (AdalException ex)
            //{
            //   message.Content = "failed login";
            //    MessageBox.Show(ex.Message);
            //}

        }
    }
}