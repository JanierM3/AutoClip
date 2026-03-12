using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AutoClips.Core;

public class ReplayBuffer
{
    private readonly Queue<Bitmap>buffer;
    private readonly int maxFrame;

    public ReplayBuffer(int maxFrame)
    {
        /*
            -Establece el tamaño máximo del buffer
            -Crea una cola para almacenar los frames
        */
        this.maxFrame = maxFrame; // 
        buffer = new Queue<Bitmap>(); 
    }

    public void AddFrame(Bitmap frame)
    {
        if (buffer.Count >= maxFrame)
        {
            var oldFrame = buffer.Dequeue();
            oldFrame.Dispose();
        }
        buffer.Enqueue(frame);
    }

    public List<Bitmap> GetFrames()
    {
        return new List<Bitmap>(buffer);
    }
}
