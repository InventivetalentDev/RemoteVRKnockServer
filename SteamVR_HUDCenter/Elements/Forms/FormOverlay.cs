﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

using Valve.VR;
using OpenTK.Graphics.OpenGL;
using System.Threading;

namespace SteamVR_HUDCenter.Elements.Forms
{
    public class FormOverlay : Overlay
    {
        public VRForm FormToShow { get; private set; }
        private int? TextureID;
        private Texture_t FormTexture;
        private Bitmap controlImage;

        public FormOverlay(string FriendlyName,
            string ThumbnailPath,
            float Width,
            VRForm FormToShow)
            : base(FriendlyName, ThumbnailPath, Width, VROverlayInputMethod.Mouse)
        {
            this.FormToShow = FormToShow;
            FormToShow.Overlay = this;
            FormToShow.Show();
            FormToShow.OnVRPaint += FormToShow_OnVRPaint;
        }

        private void FormOverlay_OnVREvent_MouseButtonDown(VREvent_Data_t Data)
        {
        }

        private void FormOverlay_OnVREvent_MouseButtonUp(VREvent_Data_t Data)
        {
        }

        private MouseButtons ParseMouseButton(VREvent_Mouse_t mouse)
        {
            switch(mouse.button)
            {
                case (uint)EVRMouseButton.Left:
                    return MouseButtons.Left;
                case (uint)EVRMouseButton.Right:
                    return MouseButtons.Right;
                case (uint)EVRMouseButton.Middle:
                    return MouseButtons.Middle;
                default:
                    return MouseButtons.None;
            }
        }

        public override void OnVREvent_MouseButtonUp(VREvent_Data_t Data)
        {
            FormToShow.SimulateMouseUpEvent(ParseMouseButton(Data.mouse), (int)(Data.mouse.x * FormToShow.Width), (int)(Data.mouse.y * FormToShow.Height), 0);
        }

        public override void OnVREvent_MouseButtonDown(VREvent_Data_t Data)
        {
            FormToShow.SimulateMouseDownEvent(ParseMouseButton(Data.mouse), (int)(Data.mouse.x * FormToShow.Width), (int)(Data.mouse.y * FormToShow.Height), 0);
        }

        public override void OnVREvent_MouseMove(VREvent_Data_t Data)
        {
            FormToShow.SimulateMouseMoveEvent((int)(Data.mouse.x * FormToShow.Width), (int)(Data.mouse.y * FormToShow.Height), 0);
        }

        private void FormToShow_OnVRPaint(Control control, Point delta, PaintEventArgs e)
        {
            DrawGraphics(control, delta, e);
        }

        public void DrawGraphics(Control control, Point delta, PaintEventArgs e)
        {
            if (TextureID.HasValue)
                GL.DeleteTexture(TextureID.Value);

            TextureID = GL.GenTexture();


            if (controlImage == null || controlImage.Size != FormToShow.Size)
            {
                controlImage = new Bitmap(FormToShow.Width, FormToShow.Height);
                using (Graphics tempG = Graphics.FromImage(controlImage))
                {
                    tempG.FillRectangle(new SolidBrush(FormToShow.BackColor), new Rectangle(0, 0, FormToShow.Width, FormToShow.Height));
                }
            }
            //FormToShow.DrawToBitmap(controlImage, new Rectangle(0, 0, FormToShow.Width, FormToShow.Height));

            using (Bitmap temp = new Bitmap(control.Width, control.Height))
            {
                try { control.DrawToBitmap(temp, new Rectangle(0, 0, control.Width, control.Height)); }
                catch (ArgumentException ex) { UDebug.LogWarning(String.Format("Exception drawing {0} control...", control.Name)); }

                using (Graphics g = Graphics.FromImage(controlImage))
                    g.DrawImage(temp, delta);

                using (Bitmap tempRotation = new Bitmap(controlImage))
                {
                    tempRotation.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    System.Drawing.Imaging.BitmapData TextureData =
                    tempRotation.LockBits(
                            new Rectangle(0, 0, tempRotation.Width, tempRotation.Height),
                            System.Drawing.Imaging.ImageLockMode.ReadOnly,
                            System.Drawing.Imaging.PixelFormat.Format32bppArgb
                        );

                    GL.BindTexture(TextureTarget.Texture2D, TextureID.Value);
                    GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, tempRotation.Width, tempRotation.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, TextureData.Scan0);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);


                    tempRotation.UnlockBits(TextureData);

                    FormTexture = new Texture_t();
                    FormTexture.eType = ETextureType.OpenGL;
                    FormTexture.eColorSpace = EColorSpace.Auto;
                    FormTexture.handle = (IntPtr)TextureID.Value;

                    if (Controller != null)
                        OpenVR.Overlay.SetOverlayTexture(this.Handle, ref FormTexture);
                }
                System.GC.Collect(); //Not really optimized
            }
        }
    }
}
