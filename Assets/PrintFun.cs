using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESC_POS_USB_NET.Printer;
using System.Text;
using System.Drawing;
//using System.IO;



public class PrintFun : MonoBehaviour
{
    

    // Texture2D loadTexture = new Texture2D(1, 1); 
    //loadTexture.LoadImage(bytes);
    //ImageConversion.LoadImage(Texture2D, byte[]);

    void Start()
    {
        InitializeEncoding();
    }

    static void InitializeEncoding()
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
       // System.Text.Encoding.GetEncoding("utf-32");
    }
    Printer printer = new Printer("XP-80C (copy 1)");
    //  Bitmap image = new Bitmap(Bitmap.FromFile("Assets/urdead.bmp"));
    //  Bitmap image1 = new Bitmap(Bitmap.FromFile("Assets/shahada.bmp"));



    public void ToPrintLoss()
    {

        printer.Separator('*'); // .
        printer.SetLineHeight(140);
        printer.Append("e7na 3arfeen enak 7ay");
        printer.Append("e7na shayfeenak odamna");
        printer.Append("bas dah mesh kefaya");
        printer.Append("lazem shehadet 7ayah rasmeya");
        printer.Append("3ady 3aleina bokra w 7awel mara kaman");
        printer.Append("5aleek motafa2el w tawel balak");
        printer.Separator('*'); // .
        printer.FullPaperCut();
        printer.PrintDocument();
    }

    public void ToPrintWin()
    {
        printer.DoubleWidth2();
        printer.BoldMode("Shahadet el 7ayah");
        printer.Separator('*'); // .
        printer.NormalWidth();
        printer.SetLineHeight(140);
        printer.Append("ana el mowaka3 asfaloho");
        printer.Append("ra2ees modeeer wazeer");
        printer.Append("el masla7a el 3amma lel 7ayah");
        printer.Append("ashad en al mosama");
        printer.Append("al esm: esmak");
        printer.Append("al lakab: lakabak");
        printer.Append("taree5 el milad: fl mady");
        printer.Append("makan el milad: fih makan ma");
        printer.Append("bena2an 3ala 2adaa el mosama");
        printer.Append("fih akher 3edet daka2ek");
        printer.Append("3ala qeid el 7ayah");
        printer.Append("ela 3'ayet yawmena haza");
        printer.Separator('*'); // .
        printer.FullPaperCut();
        printer.PrintDocument();
    }
}
