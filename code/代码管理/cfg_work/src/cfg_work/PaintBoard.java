package cfg_work;

import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.Cursor;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Point;
import java.awt.Toolkit;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseMotionAdapter;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JPanel;

//�Զ�����壬��������ͼƬ
class PaintBoard extends JPanel {
	
	public PaintBoard() {
		super();
		
		stroke = new BasicStroke(1);	//��ʼ��Ϊ�����1����ʽ
		
		//�õ�ԭ����ߴ�(Ĭ��Ϊȫ��ʱ�ĳߴ�)
		boardWidth = Toolkit.getDefaultToolkit().getScreenSize().width;
		boardHeight = Toolkit.getDefaultToolkit().getScreenSize().height;
		
		//����ͼƬĬ�ϳߴ�Ϊ����ߴ�
		imageWidth = boardWidth;
		imageHeight = boardHeight;
		
		//��ʼ��ͼƬ����
		bufferedImage = new BufferedImage(boardWidth, boardHeight, BufferedImage.TYPE_INT_RGB);
		//��ͼ����
		g = bufferedImage.createGraphics();
		g.setColor(Color.black);
		
		clear();	//��ջ���

		this.setBackground(Color.white);
		this.setCursor(new Cursor(Cursor.CROSSHAIR_CURSOR));
		this.addMouseMotionListener(new BoardMouseMoveListener());
		this.addMouseListener(new BoardMouseListener());
		this.setPreferredSize(new Dimension(boardWidth, boardHeight));
		this.setDoubleBuffered(true);
	}
	
	@Override
	protected void paintComponent(Graphics g) {
		super.paintComponent(g);
		
		Graphics2D g2d = (Graphics2D)g;
		g2d.setStroke(stroke);
		g2d.setColor(nowColor);
		g2d.drawImage(bufferedImage, 0, 0, imageWidth, imageHeight, null);
		
		if (isShape && nowPoint != null)	//�����ͼ�Σ�����ʱ�Ƚ�ͼ�λ��������
			shape.draw((Graphics2D)g, lastPoint, nowPoint);
			
	}
	
	// ��������ƶ��¼�����
	class BoardMouseMoveListener extends MouseMotionAdapter {

		@Override
		public void mouseDragged(MouseEvent e) {
			if (!isShape) {	//��Ǧ�ʻ���Ƥ��ͼ
				g.drawLine(lastPoint.x, lastPoint.y, e.getX(), e.getY());
				lastPoint = e.getPoint();
			} else {	//������ͼ��
				nowPoint = e.getPoint();
				 
				 if (e.isShiftDown())	//shift������ʱ������״
					 resetPointToRegular();
			}
			repaint();
		}
	}
	
	// ���������/�ͷ��¼�����
	class BoardMouseListener extends MouseAdapter {
		@Override
		public void mousePressed(MouseEvent e) {
			lastPoint = e.getPoint();
		}

		@Override
		public void mouseReleased(MouseEvent e) {
			if (isShape) {	//��ͼ�����õػ���ͼƬ��
				shape.draw(g, lastPoint, nowPoint);
				repaint();
			}
		}

	}
	
	//����panel����ʾ��ͼƬ
	public void setImage(File file) {
		Color beforeColor = g.getColor();		//��ס֮ǰ��ɫ
		
		image = new ImageIcon(file.getAbsolutePath());	//��ͼƬ
		//����ͼƬ��Ϣ
		imageWidth = image.getIconWidth();
		imageHeight = image.getIconHeight();
		
		this.setPreferredSize(new Dimension(imageWidth, imageHeight));	//preferredSize��ʵ�ʴ������ʵ�ֹ���
		
		//���»�ͼ����
		bufferedImage.flush();
		bufferedImage = new BufferedImage(imageWidth, imageHeight, BufferedImage.TYPE_INT_RGB);
		g = bufferedImage.createGraphics();
		g.setColor(beforeColor);
		g.drawImage(image.getImage(), 0, 0, imageWidth, imageHeight, image.getImageObserver());
		
		//���ԭ������
		lastPoint = null;
		nowPoint = null;
		
		repaint();
	}
	
	//��ջ���
	public void clear() {
		Color beforeColor = g.getColor();	//��ס֮ǰ����ɫ
		
		g.setColor(Color.white);
		g.fillRect(0, 0, imageWidth, imageHeight);
		
		g.setColor(beforeColor);	//��ԭ��ɫ
		
		//���ԭ������Ϣ
		lastPoint = null;
		nowPoint = null;
	}
	
	//�������ļ�
	public void saveToFile(File file)  {
		try {
			ImageIO.write(bufferedImage, "jpg", file);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	//������״
	public void setShape(Shape s) {
		shape = s;
		if (shape == null)
			isShape = false;
		else
			isShape = true;
		
		if (isEraser) {	//֮ǰ������Ƥ
			//��ԭ��ɫ
			g.setColor(beforColor);	
			nowColor = beforColor;

			isEraser = false;
		}
	}
	
	//������ɫ
	public void setColor(Color color) {
		nowColor = color;
		g.setColor(color);
	}
	//���ص�ǰ��ɫ
	public Color getColor() {
		return g.getColor();
	}
	
	//������Ƥ
	public void setIsEraser(boolean b) {
		isEraser = b;
	}
	
	public boolean getIsEraser() {
		return isEraser;
	}
	
	//������������
	public void setStroke(BasicStroke s) {
		stroke = s;
		g.setStroke(s);
	}
	public BasicStroke getStroke() {
		return stroke;
	}
	
	//����״����Ϊ���Ĺ���ͼ��
	private void resetPointToRegular() {
		if (shape instanceof Line) {	//ֱ�ߵ���Ϊˮƽ��ֱ
			
			int a = Math.abs(nowPoint.y - lastPoint.y);		//�Ա�
			int b = Math.abs(nowPoint.x - lastPoint.x);		//�ڱ�
			
			if (a / b > 1)	//�Ƕȴ���45�ȣ�ƫ���ڴ�ֱ����
				nowPoint.x = lastPoint.x;
			else	//�Ƕ�С��45�ȣ�ƫ����ˮƽ����
				nowPoint.y = lastPoint.y;	
			
		} else {	//����ͼ�ε���Ϊ��
			
			int width = Math.abs(nowPoint.x - lastPoint.x);
			int height = Math.abs(nowPoint.y - lastPoint.y);
			int distance = Math.abs(width - height);
			
			//����ԭ��Զ�ı�����
			if (height > width) {	//��������
				if (nowPoint.y > lastPoint.y)
					nowPoint.y -= distance;
				else
					nowPoint.y += distance;
			} else {	//��������
				if (nowPoint.x > lastPoint.x)
					nowPoint.x -= distance;
				else
					nowPoint.x += distance;
			}
			
		}
	}
	
	
	//***************************************************
	public Color beforColor = Color.black;	//ʹ����Ƥ֮ǰ����ɫ
	private Color nowColor = Color.black;	//��ǰʹ�õ���ɫ
	private BasicStroke stroke;	//������ʽ
	private Shape shape = null;	//��ǰҪ����ͼ��,null��ʾǦ��
    private Graphics2D g;	//ͼƬ��ͼ����
	private ImageIcon image;		//������ͼ��ͼ��
	private BufferedImage bufferedImage;	//ͼƬ����
	private boolean isShape = false;	//��ʾ�����Ƿ�Ϊ��׼ͼ��
	private boolean isEraser = false;	//��ʾ��ǰ�Ƿ�Ϊ��Ƥ
	private Point lastPoint = new Point(0, 0);		//ͼ�ε����Ͻ�λ��
	private Point nowPoint;		//��굱ǰλ��
	private int imageWidth;		//ͼƬ��
	private int imageHeight;	//ͼƬ��
	private int boardWidth;		//�����
	private int boardHeight;	//�����
}
