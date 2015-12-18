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

//自定义面板，用来放置图片
class PaintBoard extends JPanel {
	
	public PaintBoard() {
		super();
		
		stroke = new BasicStroke(1);	//初始化为宽度是1的样式
		
		//得到原画板尺寸(默认为全屏时的尺寸)
		boardWidth = Toolkit.getDefaultToolkit().getScreenSize().width;
		boardHeight = Toolkit.getDefaultToolkit().getScreenSize().height;
		
		//设置图片默认尺寸为画板尺寸
		imageWidth = boardWidth;
		imageHeight = boardHeight;
		
		//初始化图片缓冲
		bufferedImage = new BufferedImage(boardWidth, boardHeight, BufferedImage.TYPE_INT_RGB);
		//画图工具
		g = bufferedImage.createGraphics();
		g.setColor(Color.black);
		
		clear();	//清空画板

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
		
		if (isShape && nowPoint != null)	//如果有图形，就暂时先将图形画在面板上
			shape.draw((Graphics2D)g, lastPoint, nowPoint);
			
	}
	
	// 画板鼠标移动事件监听
	class BoardMouseMoveListener extends MouseMotionAdapter {

		@Override
		public void mouseDragged(MouseEvent e) {
			if (!isShape) {	//用铅笔或橡皮作图
				g.drawLine(lastPoint.x, lastPoint.y, e.getX(), e.getY());
				lastPoint = e.getPoint();
			} else {	//画规则图形
				nowPoint = e.getPoint();
				 
				 if (e.isShiftDown())	//shift键按下时画正形状
					 resetPointToRegular();
			}
			repaint();
		}
	}
	
	// 画板鼠标点击/释放事件监听
	class BoardMouseListener extends MouseAdapter {
		@Override
		public void mousePressed(MouseEvent e) {
			lastPoint = e.getPoint();
		}

		@Override
		public void mouseReleased(MouseEvent e) {
			if (isShape) {	//把图形永久地画在图片上
				shape.draw(g, lastPoint, nowPoint);
				repaint();
			}
		}

	}
	
	//设置panel中显示的图片
	public void setImage(File file) {
		Color beforeColor = g.getColor();		//记住之前颜色
		
		image = new ImageIcon(file.getAbsolutePath());	//打开图片
		//更新图片信息
		imageWidth = image.getIconWidth();
		imageHeight = image.getIconHeight();
		
		this.setPreferredSize(new Dimension(imageWidth, imageHeight));	//preferredSize比实际大则可以实现滚动
		
		//更新画图工具
		bufferedImage.flush();
		bufferedImage = new BufferedImage(imageWidth, imageHeight, BufferedImage.TYPE_INT_RGB);
		g = bufferedImage.createGraphics();
		g.setColor(beforeColor);
		g.drawImage(image.getImage(), 0, 0, imageWidth, imageHeight, image.getImageObserver());
		
		//清除原先数据
		lastPoint = null;
		nowPoint = null;
		
		repaint();
	}
	
	//清空画板
	public void clear() {
		Color beforeColor = g.getColor();	//记住之前的颜色
		
		g.setColor(Color.white);
		g.fillRect(0, 0, imageWidth, imageHeight);
		
		g.setColor(beforeColor);	//还原颜色
		
		//清空原来的信息
		lastPoint = null;
		nowPoint = null;
	}
	
	//保存至文件
	public void saveToFile(File file)  {
		try {
			ImageIO.write(bufferedImage, "jpg", file);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	//设置形状
	public void setShape(Shape s) {
		shape = s;
		if (shape == null)
			isShape = false;
		else
			isShape = true;
		
		if (isEraser) {	//之前用了橡皮
			//还原颜色
			g.setColor(beforColor);	
			nowColor = beforColor;

			isEraser = false;
		}
	}
	
	//设置颜色
	public void setColor(Color color) {
		nowColor = color;
		g.setColor(color);
	}
	//返回当前颜色
	public Color getColor() {
		return g.getColor();
	}
	
	//设置橡皮
	public void setIsEraser(boolean b) {
		isEraser = b;
	}
	
	public boolean getIsEraser() {
		return isEraser;
	}
	
	//设置线条属性
	public void setStroke(BasicStroke s) {
		stroke = s;
		g.setStroke(s);
	}
	public BasicStroke getStroke() {
		return stroke;
	}
	
	//将形状调整为正的规则图形
	private void resetPointToRegular() {
		if (shape instanceof Line) {	//直线调整为水平或垂直
			
			int a = Math.abs(nowPoint.y - lastPoint.y);		//对边
			int b = Math.abs(nowPoint.x - lastPoint.x);		//邻边
			
			if (a / b > 1)	//角度大于45度，偏向于垂直方向
				nowPoint.x = lastPoint.x;
			else	//角度小于45度，偏向于水平方向
				nowPoint.y = lastPoint.y;	
			
		} else {	//其他图形调整为正
			
			int width = Math.abs(nowPoint.x - lastPoint.x);
			int height = Math.abs(nowPoint.y - lastPoint.y);
			int distance = Math.abs(width - height);
			
			//将离原点远的边缩短
			if (height > width) {	//纵向缩短
				if (nowPoint.y > lastPoint.y)
					nowPoint.y -= distance;
				else
					nowPoint.y += distance;
			} else {	//横向缩短
				if (nowPoint.x > lastPoint.x)
					nowPoint.x -= distance;
				else
					nowPoint.x += distance;
			}
			
		}
	}
	
	
	//***************************************************
	public Color beforColor = Color.black;	//使用橡皮之前的颜色
	private Color nowColor = Color.black;	//当前使用的颜色
	private BasicStroke stroke;	//画笔样式
	private Shape shape = null;	//当前要画的图形,null表示铅笔
    private Graphics2D g;	//图片作图工具
	private ImageIcon image;		//用来画图的图像
	private BufferedImage bufferedImage;	//图片缓冲
	private boolean isShape = false;	//标示所画是否为标准图形
	private boolean isEraser = false;	//标示当前是否为橡皮
	private Point lastPoint = new Point(0, 0);		//图形的左上角位置
	private Point nowPoint;		//鼠标当前位置
	private int imageWidth;		//图片宽
	private int imageHeight;	//图片高
	private int boardWidth;		//画板宽
	private int boardHeight;	//画板高
}
