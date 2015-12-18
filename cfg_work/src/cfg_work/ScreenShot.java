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
	private ShotImagePanel imagePanel=null;//��ͼ���
	//private ActionPanel actionPanel=null;//�������
	
	public MainFrame(){
		//û�б߿�Ҫ���ô���ȫ��
		//setTitle("��ͼ���");
		//setSize(500,800);
		setLayout(null);
		//setVisible(true);	
		setUndecorated(true);//ȥ������ı߿�
		//��ʼ�����
		initComp();
		setFullScreen();
		//����ĳ�������д���
		
		this.addKeyListener(new KeyAdapter() {
			@Override
			public void keyPressed(KeyEvent e) {
				// TODO Auto-generated method stub
				if(e.getKeyCode()==KeyEvent.VK_ESCAPE){
					System.exit(0);//�˳�
				}
				if(e.getKeyCode()==KeyEvent.VK_ENTER){
					saveImage();
				}
			}
		});
	}
	//���ô���ȫ����ʾ
	private void setFullScreen(){
		//��ȡ�û�ͼ����ʾ�豸�Ķ���
		GraphicsDevice device=GraphicsEnvironment.getLocalGraphicsEnvironment().getDefaultScreenDevice();
		//�ж��ǲ���֧��ȫ��
		if(device.isFullScreenSupported()){
			device.setFullScreenWindow(this);
			
		}
	}
	//��ʼ�����ڵ�����,���
	private void initComp(){
		//�½�һ����ͼ���
		imagePanel=new ShotImagePanel(this);
		this.add(imagePanel);
		//�½��������
		//actionPanel=new ActionPanel(this);
		//this.add(actionPanel);
		//actionPanel.setLocation(0, 0);
	}
	//��ʾ�������
	/*public void showtool(int x,int y){
		this.actionPanel.setLocation(x, y);
		this.actionPanel.setVisible(true);
		this.actionPanel.repaint();
	}
	//���ع������
	public void hidetool(){
		this.actionPanel.setVisible(false);
	}*/
	//����ͼƬ
	public void saveImage(){
		//�˳�ȫ����״̬
		GraphicsDevice device=GraphicsEnvironment.getLocalGraphicsEnvironment().getDefaultScreenDevice();
		//�ж��ǲ���֧��ȫ��
		if(device.isFullScreenSupported()){
			device.setFullScreenWindow(null);
	}
	this.imagePanel.saveImage();
	
	
	}
}
//��ͼ���
class ShotImagePanel extends JPanel{
	private SimpleDateFormat sdf=new SimpleDateFormat("yyyymmddHHmmss");
	//�����û����������ʼ������յ�����
	private int startX,startY,endX,endY;
	//��ȡ������Ļ������ΪͼƬ
	private BufferedImage image=null;
	private BufferedImage tempimage=null;//�Խ�ͼͼƬ���д���������ɫ
	private BufferedImage saveimage=null;//��Ҫ�����ͼƬ
	private MainFrame parent=null;
	public ShotImagePanel(MainFrame parent){
		this.parent=parent;
		//��ȡ��Ļ�ߴ�
		Dimension d=Toolkit.getDefaultToolkit().getScreenSize();
		this.setBounds(0,0,d.width,d.height);
		//��ȡ��Ļ
		try {
		      Robot robot=new Robot();
		      //��ȡ��Ļ
		      image=robot.createScreenCapture(new Rectangle(0, 0,d.width,d.height));
		} catch (AWTException e) {
			// TODO Auto-generated catch block
			System.out.print("��ʼ��ʧ��");
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
				//��ȡ����x��y������
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
				//����϶���ʱ��ʵʱ��ȡx��y������
				endX=e.getX();
				endY=e.getY();
				//����һ����ʱͼ��
				Image tempImage=createImage(ShotImagePanel.this.getWidth(),ShotImagePanel.this.getHeight());
				//��ȡһ������
				Graphics g=tempImage.getGraphics();
				g.drawImage(tempimage,0,0,null);
				//�����������С��һ��
				int x=Math.min(startX, endX);
				int y=Math.min(startY, endY);
				//��ÿ�Ⱥ͸߶�
				int width=Math.abs(startX-endX)+1;
				int height=Math.abs(startY-endY)+1;
				//�����������û�����ɫ
				g.setColor(Color.RED);
				g.drawRect(x-1, y-1, width+1, height+1);
				//�ü���ͼѡ���Сͼ
				saveimage=image.getSubimage(x, y, width, height);
				g.drawImage(saveimage, x, y, null);
				//������ʱͼ��
				ShotImagePanel.this.getGraphics().drawImage(tempImage,0,0,ShotImagePanel.this);
				
			}
		});
	}
	
	@Override
	public void paint(Graphics g){
		super.paint(g);
		//����ͼƬ
		RescaleOp ro=new RescaleOp(0.6f, 0, null);
		tempimage=ro.filter(image, null);
		//����ͼƬ
		g.drawImage(tempimage, 0, 0, this);
	}
	
	//����ͼƬ�ķ���
			public void saveImage(){
				JFileChooser jfc=new JFileChooser();
				jfc.setDialogTitle("����ͼƬ");
				//�ļ�ѡ����
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
						System.out.println("�����ļ��쳣");
					}
				}
				System.exit(0);
			}
	
}
//�������
/*class ActionPanel extends JPanel{
	private MainFrame parent=null;
	public ActionPanel(MainFrame parent){
		this.parent=parent;
		setLayout(new BorderLayout());
		setSize(80,40);//���ô�С
		setVisible(false);
		initComp();
		
		
	}
	//��ʼ�������������ӵ������
	private void initComp(){
		
		//������
		JToolBar actionBar=new JToolBar("");
		actionBar.setFloatable(false);//�����ƶ�
		JButton savabtn=new JButton("����");//���水ť
		//JButton savabtn=new JButton(new ImageIcon("images/save.gif"));//���水ť
	   savabtn.addActionListener(new ActionListener() {
		
		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			ActionPanel.this.parent.saveImage();
		}
	});
		actionBar.add(savabtn);
	    
	    //JButton closebtn=new JButton(new ImageIcon("images/close.gif"));//���水ť
		JButton closebtn=new JButton("�ر�");
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
