using GdPicture14;
using maui_test.ViewModels;
using System;
using System.Diagnostics;

namespace maui_test;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        ((MainViewModel)this.BindingContext).SetViewer(GdViewer1);
    }


    private async void LoadDocument(object sender, EventArgs e)
    {
        GdViewer1.CloseDocument();
        var file = await FilePicker.Default.PickAsync();

        if (file != null && !string.IsNullOrEmpty(file.FullPath))
        {
            GdViewer1.DocumentSource = file.FullPath;
        }
    }


    private void Zoom25(object sender, EventArgs e)
    {
        GdViewer1.Zoom = 0.25;
    }


    private void Zoom50(object sender, EventArgs e)
    {
        GdViewer1.Zoom = 0.5;
    }


    private void Zoom100(object sender, EventArgs e)
    {
        GdViewer1.Zoom = 1;
    }


    private void Zoom150(object sender, EventArgs e)
    {
        GdViewer1.Zoom = 1.5;
    }


    private void Zoom200(object sender, EventArgs e)
    {
        GdViewer1.Zoom = 2;
    }


    private void RotateView90(object sender, EventArgs e)
    {
        GdViewer1.RotateView(GdPictureRotateFlipType.GdPictureRotate90FlipNone);
    }


    private void RotateView270(object sender, EventArgs e)
    {
        GdViewer1.RotateView(GdPictureRotateFlipType.GdPictureRotate270FlipNone);
    }


    private void SinglePageView(object sender, EventArgs e)
    {
        GdViewer1.PageDisplayMode = PageDisplayMode.SinglePageView;
    }


    private void MultipageView(object sender, EventArgs e)
    {
        GdViewer1.PageDisplayMode = PageDisplayMode.MultiplePagesView;
    }


    private void HighlightSelectedText(object sender, EventArgs e)
    {
        GdViewer1.HighlightSelectedText();
    }


    private void GdViewer1_PasswordRequest(object sender, GdPicture14.MAUI.GdViewer.PasswordRequestEventArgs e)
    {
        //todo: implement logic to prompt user to enter a password.
    }
}