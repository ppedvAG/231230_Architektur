namespace WinFormsCustomButton
{
    internal class MyButton : Button
    {
        int c = 0;
        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.FillRectangle(new SolidBrush(Parent.BackColor), ClientRectangle);
            pevent.Graphics.FillEllipse(Brushes.OrangeRed, ClientRectangle);
            
            var sf = new StringFormat() { LineAlignment = StringAlignment.Center,Alignment=StringAlignment.Center };
            pevent.Graphics.DrawString(Text,SystemFonts.DefaultFont,Brushes.Beige, ClientRectangle,sf);


            c++;

            Parent.Text = $"{c} paintcount";
        }

    }
}
