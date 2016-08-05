using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using D3D = Microsoft.DirectX.Direct3D;

namespace direct3
{
    public partial class directx : Form
    {
        Device device = null;
        int[,] texturenum = new int[100, 100];
        Texture texture1;
        Texture texture2;
        Texture texture3;
        Texture[,] people = new Texture[4, 4];
        int movespeed = 10;
        int x = 0;
        int y = 0;
        int fangxiang = 0;
        int maxx = 0;
        bool paused = false;
        int minx = 0;
        int miny = 0;
        D3D.Sprite d3dsprite;
        Random rnd = new Random();
        public directx()
        {
            InitializeComponent();
        }
        public bool InitializeGraphics()
        {
            try
            {
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true;
                presentParams.SwapEffect = SwapEffect.Discard;
                presentParams.BackBufferFormat = Format.Unknown;
                presentParams.AutoDepthStencilFormat = DepthFormat.D16;
                presentParams.EnableAutoDepthStencil = true;

                int adapterOrdinal = D3D.Manager.Adapters.Default.Adapter;
                CreateFlags flags = CreateFlags.SoftwareVertexProcessing;
                D3D.Caps caps = D3D.Manager.GetDeviceCaps(adapterOrdinal, D3D.DeviceType.Hardware);
                if (caps.DeviceCaps.SupportsHardwareTransformAndLight)
                { flags = CreateFlags.HardwareVertexProcessing; }

                device = new Device(0, DeviceType.Hardware, this, flags, presentParams);
                device.DeviceLost += new EventHandler(this.InvalidateDeviceObjects);
                device.DeviceReset += new EventHandler(this.RestoreDeviceObjects);
                device.Disposing += new EventHandler(this.DeleteDeviceObjects);
                device.DeviceResizing += new CancelEventHandler(this.EnvironmentResizeing);
                texture1 = TextureLoader.FromFile(device, Application.StartupPath + "\\行走画面\\map0.bmp", 50, 50, 1, 0, Format.A8R8G8B8, Pool.Managed, Filter.Point, Filter.Point, (unchecked((int)0xff000000)));
                texture2 = TextureLoader.FromFile(device, Application.StartupPath + "\\行走画面\\map1.bmp", 50, 50, 1, 0, Format.A8R8G8B8, Pool.Managed, Filter.Point, Filter.Point, (unchecked((int)0xff000000)));
                texture3 = TextureLoader.FromFile(device, Application.StartupPath + "\\行走画面\\map2.bmp", 62, 82, 1, 0, Format.A8R8G8B8, Pool.Managed, Filter.Point, Filter.Point, (unchecked((int)0xff000000)));
                for (int k = 0; k < 4; k++)
                {
                    for (int l = 0; l < 4; l++)
                    {
                        people[k, l] = TextureLoader.FromFile(device, Application.StartupPath + "\\行走画面\\Char" + (k * 4 + l).ToString() + ".bmp", 62, 82, 1, 0, Format.A8R8G8B8, Pool.Managed, Filter.Point, Filter.Point, (unchecked((int)0xff000000)));
                    }
                }
                d3dsprite = new Sprite(device);
                return true;
            }
            catch (DirectXException)
            {
                return false;
            }
        }
        protected virtual void InvalidateDeviceObjects(object sender, EventArgs e)
        { }
        protected virtual void RestoreDeviceObjects(object sender, EventArgs e)
        { D3D.Device device = (D3D.Device)sender; }
        protected virtual void DeleteDeviceObjects(object sender, EventArgs e)
        { }
        protected virtual void EnvironmentResizeing(object sender, CancelEventArgs e)
        { e.Cancel = true; }
        protected virtual void FrameMove()
        { }
        protected virtual void Render()
        {
            if (device != null)
            {
                device.Clear(ClearFlags.Target, Color.Transparent, 1.0f, 0);
                device.BeginScene();
                this.DrawMap();
                device.EndScene();
                device.Present();
            }
        }
        public void Run()
        {
            while (Created)
            {
                FrameMove();
                Render();
                Application.DoEvents();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            this.Render();
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if ((int)e.KeyChar == (int)System.Windows.Forms.Keys.Escape)
            {
                this.Close();
            }
        }
        private void DrawMap()
        {

            d3dsprite.Begin(SpriteFlags.AlphaBlend);
            for (int i = (45 + minx); i < (55 + minx); i++)
            {
                for (int j = (45 + miny); j < (55 + miny); j++)
                {
                    if (texturenum[i, j] == 0)
                    {
                        d3dsprite.Draw(texture1, new Rectangle(0, 0, 50, 50), new Vector3(0f, 0f, 0f), new Vector3(((float)(i - 45 - minx) * 50), ((float)(j - (45 + miny)) * 50), 0f), Color.FromArgb(255, 255, 255, 255));
                    }
                    else if (texturenum[i, j] == 1)
                    {
                        d3dsprite.Draw(texture2, new Rectangle(0, 0, 50, 50), new Vector3(0f, 0f, 0f), new Vector3(((float)(i - 45 - minx) * 50), ((float)(j - (45 + miny)) * 50), 0f), Color.FromArgb(255, 255, 255, 255));
                    }
                    else
                    {
                        d3dsprite.Draw(texture3, new Rectangle(0, 0, 50, 50), new Vector3(0f, 0f, 0f), new Vector3(((float)(i - 45 - minx) * 50), ((float)(j - (45 + miny)) * 50), 0f), Color.FromArgb(255, 255, 255, 255));
                    }
                }
            }
            if (!paused)
            {
                d3dsprite.Draw(people[this.fangxiang, x % 4], new Rectangle(0, 0, 62, 82), new Vector3(0f, 0f, 1f), new Vector3(250f, 250f, 1f), Color.FromArgb(255, 255, 255, 255));
            }
            else
            {
                x = 0;
                d3dsprite.Draw(people[this.fangxiang, x % 4], new Rectangle(0, 0, 62, 82), new Vector3(0f, 0f, 1f), new Vector3(250f, 250f, 1f), Color.FromArgb(255, 255, 255, 255));
            }
            d3dsprite.End();
        }
        private void Initiallizetexturenum()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    texturenum[i, j] = rnd.Next(0, 3);
                }
            }
        }

        private void directx_Load(object sender, EventArgs e)
        {
            this.Initiallizetexturenum();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x = x + 1;
        }

        private void directx_KeyDown(object sender, KeyEventArgs e)
        {
            this.paused = false;
            timer1.Enabled = true;
            timer2.Enabled = true;
            if (e.KeyCode == Keys.Down)
            {

                this.fangxiang = 0;
                maxx = 1;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.fangxiang = 3;
                maxx = 2;
            }
            if (e.KeyCode == Keys.Right)
            {
                this.fangxiang = 2;
                maxx = 3;
            }
            if (e.KeyCode == Keys.Left)
            {
                this.fangxiang = 1;
                maxx = 4;
            }
            this.label2.Text = y.ToString();
        }

        private void directx_KeyUp(object sender, KeyEventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            maxx = 0;
            this.paused = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (maxx == 1)
            {
                if (miny < 45)
                {
                    miny++;
                }
            }
            if (maxx == 2)
            {
                if (miny > -45)
                {
                    miny--;
                }
            }
            if (maxx == 3)
            {
                if (minx < 45)
                {
                    minx++;
                }
            }
            if (maxx == 4)
            {
                if (minx > -45)
                {
                    minx--;
                }
            }
        }
    }
}