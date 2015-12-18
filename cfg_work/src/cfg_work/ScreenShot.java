package cfg_work;

import java.awt.AWTException;
import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.GraphicsDevice;
import java.awt.GraphicsEnvironment;
import java.awt.Image;
import java.awt.Rectangle;
import java.awt.Robot;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;
import java.awt.image.BufferedImage;
import java.awt.image.RescaleOp;
import java.io.File;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JToggleButton;
import javax.swing.JToolBar;
import javax.swing.filechooser.FileNameExtensionFilter;
import javax.swing.filechooser.FileSystemView;

public class ScreenShot {
	public ScreenShot(){
		MainFrame frame=new MainFrame();
		frame.setVisible(true);
	}

}

class MainFrame extends JFrame{
	private ShotImagePanel imagePanel=null;//截图面板
	//private ActionPanel actionPanel=null;//工具面板
	
	public MainFrame(){
		//没有边框，要设置窗体全屏
		//setTitle("截图软件");
		//setSize(500,800);
		setLayout(null);
		//setVisible(true);	
		setUndecorated(true);//去除外面的边框
		//初始化组件
		initComp();
		setFullScreen();
		//按下某个键进行处理
		
		this.addKeyListener(new KeyAdapter() {
			@Override
			public void keyPressed(KeyEvent e) {
				// TODO Auto-generated method stub
				if(e.getKeyCode()==KeyEvent.VK_ESCAPE){
					System.exit(0);//退出
				}
				if(e.getKeyCode()==KeyEvent.VK_ENTER){
					saveImage();
				}
			}
		});
	}
	//设置窗口全屏显示
	private void setFullScreen(){
		//获取用户图像显示设备的对象
		GraphicsDevice device=GraphicsEnvironment.getLocalGraphicsEnvironment().getDefaultScreenDevice();
		//判断是不是支持全屏
		if(device.isFullScreenSupported()){
			device.setFullScreenWindow(this);
			
		}
	}
	//初始化窗口的内容,组件
	private void initComp(){
		//新建一个截图面板
		imagePanel=new ShotImagePanel(this);
		this.add(imagePanel);
		//新建工具面板
		//actionPanel=new ActionPanel(this);
		//this.add(actionPanel);
		//actionPanel.setLocation(0, 0);
	}
	//显示工具面板
	/*public void showtool(int x,int y){
		this.actionPanel.setLocation(x, y);
		this.actionPanel.setVisible(true);
		this.actionPanel.repaint();
	}
	//隐藏工具面板
	public void hidetool(){
		this.actionPanel.setVisible(false);
	}*/
	//保存图片
	public void saveImage(){
		//退出全屏的状态
		GraphicsDevice device=GraphicsEnvironment.getLocalGraphicsEnvironment().getDefaultScreenDevice();
		//判断是不是支持全屏
		if(device.isFullScreenSupported()){
			device.setFullScreenWindow(null);
	}
	this.imagePanel.saveImage();
	
	
	}
}
//截图面板
class ShotImagePanel extends JPanel{
	private SimpleDateFormat sdf=new SimpleDateFormat("yyyymmddHHmmss");
	//定义用户点击鼠标的起始坐标和终点坐标
	private int startX,startY,endX,endY;
	//截取整个屏幕，保存为图片
	private BufferedImage image=null;
	private BufferedImage tempimage=null;//对截图图片进行处理，加深颜色
	private BufferedImage saveimage=null;//需要保存的图片
	private MainFrame parent=null;
	public ShotImagePanel(MainFrame parent){
		this.parent=parent;
		//获取屏幕尺寸
		Dimension d=Toolkit.getDefaultToolkit().getScreenSize();
		this.setBounds(0,0,d.width,d.height);
		//截取屏幕
		try {
		      Robot robot=new Robot();
		      //截取屏幕
		      image=robot.createScreenCapture(new Rectangle(0, 0,d.width,d.height));
		} catch (AWTException e) {
			// TODO Auto-generated catch block
			System.out.print("初始化失败");
		}
		
		this.addMouseListener(new MouseListener() {
			
			@Override
			public void mouseReleased(MouseEvent e) {
				// TODO Auto-generated method stub
				//parent.showtool(e.getX(), e.getY());
			}
			
			@Override
			public void mousePressed(MouseEvent e) {
				// TODO Auto-generated method stub
				startX=e.getX();
				startY=e.getY();
				//parent.hidetool();
			}
			
			@Override
			public void mouseExited(MouseEvent e) {
				// TODO Auto-generated method stub
				
			}
			
			@Override
			public void mouseEntered(MouseEvent e) {
				// TODO Auto-generated method stub
				
			}
			
			@Override
			public void mouseClicked(MouseEvent e) {
				// TODO Auto-generated method stub
				//获取起点的x和y的坐标
				//startX=e.getX();
				//startY=e.getY();
			}
		});
		
		
		this.addMouseMotionListener(new MouseMotionListener() {
			
			@Override
			public void mouseMoved(MouseEvent e) {
				// TODO Auto-generated method stub
				
			}
			
			@Override
			public void mouseDragged(MouseEvent e) {
				// TODO Auto-generated method stub
				//鼠标拖动的时候实时获取x和y的坐标
				endX=e.getX();
				endY=e.getY();
				//创建一个临时图像
				Image tempImage=createImage(ShotImagePanel.this.getWidth(),ShotImagePanel.this.getHeight());
				//获取一个画笔
				Graphics g=tempImage.getGraphics();
				g.drawImage(tempimage,0,0,null);
				//获得两个数中小的一个
				int x=Math.min(startX, endX);
				int y=Math.min(startY, endY);
				//获得宽度和高度
				int width=Math.abs(startX-endX)+1;
				int height=Math.abs(startY-endY)+1;
				//绘制区域，设置画笔颜色
				g.setColor(Color.RED);
				g.drawRect(x-1, y-1, width+1, height+1);
				//裁剪大图选择的小图
				saveimage=image.getSubimage(x, y, width, height);
				g.drawImage(saveimage, x, y, null);
				//绘制临时图像
				ShotImagePanel.this.getGraphics().drawImage(tempImage,0,0,ShotImagePanel.this);
				
			}
		});
	}
	
	@Override
	public void paint(Graphics g){
		super.paint(g);
		//处理图片
		RescaleOp ro=new RescaleOp(0.6f, 0, null);
		tempimage=ro.filter(image, null);
		//绘制图片
		g.drawImage(tempimage, 0, 0, this);
	}
	
	//保存图片的方法
			public void saveImage(){
				JFileChooser jfc=new JFileChooser();
				jfc.setDialogTitle("保存图片");
				//文件选择器
				FileNameExtensionFilter fiter=new FileNameExtensionFilter("JPG", "jpg");
				jfc.setFileFilter(fiter);
				
				String fileName=sdf.format(new Date());
				File filepath=FileSystemView.getFileSystemView().getHomeDirectory();
				File defaultFile=new File(filepath+File.separator+fileName+".jpg");
				jfc.setSelectedFile(defaultFile);
				int flag=jfc.showSaveDialog(this);
				if(flag==JFileChooser.APPROVE_OPTION){
					File file=jfc.getSelectedFile();
					String path=file.getPath();
					if(!path.endsWith("jpg")||!path.endsWith("JPG")){
						path+=".jpg";
					}
					try {
						ImageIO.write(saveimage, "jpg", new File(path));
					} catch (IOException e) {
						// TODO Auto-generated catch block
						System.out.println("保存文件异常");
					}
				}
				System.exit(0);
			}
	
}
//工具面板
/*class ActionPanel extends JPanel{
	private MainFrame parent=null;
	public ActionPanel(MainFrame parent){
		this.parent=parent;
		setLayout(new BorderLayout());
		setSize(80,40);//设置大小
		setVisible(false);
		initComp();
		
		
	}
	//初始化组件，并且添加到面板上
	private void initComp(){
		
		//工具箱
		JToolBar actionBar=new JToolBar("");
		actionBar.setFloatable(false);//不能移动
		JButton savabtn=new JButton("保存");//保存按钮
		//JButton savabtn=new JButton(new ImageIcon("images/save.gif"));//保存按钮
	   savabtn.addActionListener(new ActionListener() {
		
		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			ActionPanel.this.parent.saveImage();
		}
	});
		actionBar.add(savabtn);
	    
	    //JButton closebtn=new JButton(new ImageIcon("images/close.gif"));//保存按钮
		JButton closebtn=new JButton("关闭");
		closebtn.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				System.exit(0);
			}
		});
	    actionBar.add(closebtn);
	    
	    this.add(actionBar, BorderLayout.NORTH);
	}
}*/
