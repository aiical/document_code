package cfg_work;

import javax.swing.*;
import javax.swing.filechooser.FileNameExtensionFilter;

import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.event.*;
import java.io.File;

public class DrawingBoard extends JFrame {

	public static void main(String[] args) {
		try {
			// 将界面设置为当前windows风格
			UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
		} catch (Exception e) {
		}

		DrawingBoard drawingBoard = new DrawingBoard();
		drawingBoard.setVisible(true);
	}

	// “文件”选项事件监听器
	class FileActionListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			int flag = -1; // 标示那个选项被按下

			// 判断事件来源
			if (e.getSource() == mitmFileNew)
				
				flag = 0;
			if (e.getSource() == mitmFileOpen)
				flag = 1;
			if (e.getSource() == mitmFileSave)
				flag = 2;
			if (e.getSource() == mitmFileExit)
				flag = 3;

			// 处理事件
			switch (flag) {
			// “新建”选项************************
			case 0:
				paintBoard.clear();
				repaint();
				file = null;
				break;
			// “打开”选项************************
			case 1:
				openImage();
				break;
			// “保存”选项************************
			case 2:
				save();
				break;
			// “退出”选项************************
			case 3:
				DrawingBoard.this.dispose();
				break;
			}
		}

	}

	// “编辑”选项事件监听器
	class EditActionListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			int flag = -1; // 标示哪个选项被按下

			// 判断事件来源
			if (e.getSource() == mitmEditClear)
				flag = 1;

			// 处理事件
			switch (flag) {
			// “清除”选项************************
			case 1:
				paintBoard.clear();
				repaint();
				break;
			}
		}

	}

	// “画笔”选项事件监听器
	class PenActionListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			int flag = -1; // 标示哪个选项被按下
			float width = 0; // 记录原画板粗细

			// 判断事件来源
			if (e.getSource() == mitmPenPencil)
				flag = 0;
			if (e.getSource() == mitmPenEraser)
				flag = 1;
			if (e.getSource() == mitmPenColor)
				flag = 2;
			if (e.getSource() == mitmPenLine)
				flag = 3;
			if (e.getSource() == mitmPenDash)
				flag = 4;
			if (e.getSource() == mitmPenWidth1p)
				flag = 5;
			if (e.getSource() == mitmPenWidth2p)
				flag = 6;
			if (e.getSource() == mitmPenWidth3p)
				flag = 7;
			if (e.getSource() == mitmPenWidth5p)
				flag = 8;

			// 处理事件
			switch (flag) {
			// 铅笔********************************
			case 0:
				paintBoard.setShape(null);
				break;
			// 橡皮********************************
			case 1:
				if (!paintBoard.getIsEraser()) // 如果当前不是橡皮，就保存之前的颜色
					paintBoard.beforColor = paintBoard.getColor();
				paintBoard.setShape(null);
				paintBoard.setIsEraser(true);
				paintBoard.setColor(Color.white);
				break;
			// 颜色********************************
			case 2:
				Color color = JColorChooser.showDialog(DrawingBoard.this, "颜色",
						Color.black);
				if (color != null)
					paintBoard.setColor(color);
				break;
			// 实线********************************
			case 3:
				width = paintBoard.getStroke().getLineWidth(); // 记录原画笔粗细
				paintBoard.setStroke(new BasicStroke(width));
				break;
			// 虚线********************************
			case 4:
				float[] dash = { 10, 10 };
				width = paintBoard.getStroke().getLineWidth();
				BasicStroke stroke = new BasicStroke(width,
						BasicStroke.CAP_BUTT, BasicStroke.JOIN_BEVEL, 1, dash,
						0);
				paintBoard.setStroke(stroke);
				break;
			// 1像素宽********************************
			case 5:
				setLineWidth(1); // 设置线条宽度
				break;
			// 2像素宽******************************
			case 6:
				setLineWidth(2);
				break;
			// 3像素宽******************************
			case 7:
				setLineWidth(3);
				break;
			// 5像素宽******************************
			case 8:
				setLineWidth(5);
				break;
			}

		}
	}

	// “形状”选项事件监听器
	class ShapeActionListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			int flag = -1; // 标示哪个选项被按下

			// 判断事件来源
			if (e.getSource() == mitmShapeLine)
				flag = 0;
			if (e.getSource() == mitmShapeRect)
				flag = 1;
			if (e.getSource() == mitmShapeCircle)
				flag = 2;
			if (e.getSource() == mitmShapeArc)
				flag = 3;

			// 处理事件
			switch (flag) {
			// 直线********************************
			case 0:
				paintBoard.setShape(new Line());
				break;
			// 矩形********************************
			case 1:
				paintBoard.setShape(new Rectangle());
				break;
			// 椭圆********************************
			case 2:
				paintBoard.setShape(new Oval());
				break;
			// 弧********************************
			case 3:

				break;

			}
		}

	}

	// ”帮助“选项事件监听器
	class HelpActionListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			helpDialog.setVisible(true);
		}

	}
	
	//”截屏“选项事件监听器
	class ShotActionListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			new ScreenShot();
		}

	}

	// 设置线条粗细
	private void setLineWidth(int width) {
		float[] dash = paintBoard.getStroke().getDashArray(); // 记录原来的虚线信息

		paintBoard.setStroke(new BasicStroke(width, BasicStroke.CAP_BUTT,
				BasicStroke.JOIN_BEVEL, 1, dash, 0));
	}

	// 保存图片
	private void save() {
		if (file == null) { // 没有打开文件，所以要保存为新的文件
			// 让用户选择一个新文件
			JFileChooser fileChooser = new JFileChooser();
			fileChooser.setFileFilter(filter);
			int result = fileChooser.showSaveDialog(this);

			if (result == JFileChooser.APPROVE_OPTION) {
				file = fileChooser.getSelectedFile();
				paintBoard.saveToFile(file);
			}

		} else { // 保存为原文件
			paintBoard.saveToFile(file);
		}
	}

	// 打开图片
	private void openImage() {

		JFileChooser fileChooser = new JFileChooser();
		fileChooser.setFileFilter(filter); // 设定过滤器
		int result = fileChooser.showOpenDialog(fileChooser);

		if (result == JFileChooser.APPROVE_OPTION) { // 用户选择了一个正确的图片
			file = fileChooser.getSelectedFile();
			paintBoard.setImage(file); // 载入图片

			repaint();
		}

	}

	public DrawingBoard() {

		super("画图");

		// 创建过滤器
		filter = new FileNameExtensionFilter("JPEG(*.jpg;*.jpeg)", "jpg",
				"jpeg");

		// “文件”选项
		mitmFileNew = new JMenuItem("新建");
		mitmFileOpen = new JMenuItem("打开");
		mitmFileSave = new JMenuItem("保存");
		mitmFileExit = new JMenuItem("退出");

		mitmFileNew.addActionListener(fileActionListener);
		mitmFileOpen.addActionListener(fileActionListener);
		mitmFileSave.addActionListener(fileActionListener);
		mitmFileExit.addActionListener(fileActionListener);

		menuFile = new JMenu("文件");
		menuFile.add(mitmFileNew);
		menuFile.add(mitmFileOpen);
		menuFile.add(mitmFileSave);
		menuFile.add(mitmFileExit);

		// “编辑”选项
		mitmEditClear = new JMenuItem("清除");

		mitmEditClear.addActionListener(editActionListener);

		menuEdit = new JMenu("编辑");
		menuEdit.add(mitmEditClear);

		// “画笔”选项
		mitmPenPencil = new JMenuItem("铅笔");
		mitmPenEraser = new JMenuItem("橡皮");
		mitmPenColor = new JMenuItem("颜色");
		mitmPenWidth1p = new JMenuItem("1 pixel");
		mitmPenWidth2p = new JMenuItem("2 pixel");
		mitmPenWidth3p = new JMenuItem("3 pixel");
		mitmPenWidth5p = new JMenuItem("5 pixel");

		menuPenWidth = new JMenu("粗细");
		menuPenWidth.add(mitmPenWidth1p);
		menuPenWidth.add(mitmPenWidth2p);
		menuPenWidth.add(mitmPenWidth3p);
		menuPenWidth.add(mitmPenWidth5p);
		mitmPenDash = new JMenuItem("虚线");
		mitmPenLine = new JMenuItem("实线");
		menuPenType = new JMenu("虚/实");
		menuPenType.add(mitmPenDash);
		menuPenType.add(mitmPenLine);

		mitmPenPencil.addActionListener(penActionListener);
		mitmPenEraser.addActionListener(penActionListener);
		mitmPenColor.addActionListener(penActionListener);
		mitmPenLine.addActionListener(penActionListener);
		mitmPenDash.addActionListener(penActionListener);
		mitmPenWidth1p.addActionListener(penActionListener);
		mitmPenWidth2p.addActionListener(penActionListener);
		mitmPenWidth3p.addActionListener(penActionListener);
		mitmPenWidth5p.addActionListener(penActionListener);

		menuPen = new JMenu("画笔");
		menuPen.add(mitmPenPencil);
		menuPen.add(mitmPenEraser);
		menuPen.add(mitmPenColor);
		menuPen.add(menuPenType);
		menuPen.add(menuPenWidth);

		// “形状”选项
		mitmShapeLine = new JMenuItem("直线");
		mitmShapeRect = new JMenuItem("矩形");
		mitmShapeCircle = new JMenuItem("椭圆");
		mitmShapeArc = new JMenuItem("曲线");

		mitmShapeLine.addActionListener(shpaeActionListener);
		mitmShapeRect.addActionListener(shpaeActionListener);
		mitmShapeCircle.addActionListener(shpaeActionListener);
		mitmShapeArc.addActionListener(shpaeActionListener);

		menuShape = new JMenu("形状");
		menuShape.add(mitmShapeLine);
		menuShape.add(mitmShapeRect);
		menuShape.add(mitmShapeCircle);
		menuShape.add(mitmShapeArc);

		// “帮助”选项
		mitmHelpView = new JMenuItem("查看帮助");
		mitmHelpView.addActionListener(helpActionListener);

		menuHelp = new JMenu("帮助");
		menuHelp.add(mitmHelpView);
		//截屏选项
		mitmshotView=new JMenuItem("截屏功能");
		mitmshotView.addActionListener(shotActionListener);
		
		menushot = new JMenu("截屏");
		menushot.add(mitmshotView);

		// 菜单
		menuBar = new JMenuBar();
		menuBar.add(menuFile);
		menuBar.add(menuEdit);
		menuBar.add(menuPen);
		menuBar.add(menuShape);
		menuBar.add(menuHelp);
		menuBar.add(menushot);

		// //画板
		paintBoard = new PaintBoard();
		
		//帮助窗口
		helpDialog = new HelpDialog();

		// 初始化窗口
		this.setDefaultCloseOperation(EXIT_ON_CLOSE);
		this.setLocation(0, 0);
		this.setSize(1000, 700);
		this.setExtendedState(MAXIMIZED_BOTH); // 窗口最大化
		this.setJMenuBar(menuBar);
		JScrollPane scrPane = new JScrollPane(); // 新建滚动板
		scrPane.setViewportView(paintBoard);
		// 设置当需要时显示滚动条
		scrPane.setHorizontalScrollBarPolicy(JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);
		scrPane.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED);
		this.add(scrPane);
	}

	// 私有域
	private File file = null; // 当前文件
	private FileNameExtensionFilter filter; // 格式过滤器

	// 事件监听
	FileActionListener fileActionListener = new FileActionListener();
	EditActionListener editActionListener = new EditActionListener();
	PenActionListener penActionListener = new PenActionListener();
	ShapeActionListener shpaeActionListener = new ShapeActionListener();
	HelpActionListener helpActionListener = new HelpActionListener();
	ShotActionListener shotActionListener = new ShotActionListener();

	// 窗口组件
	private JMenuBar menuBar; // 菜单栏

	// 菜单选项
	private JMenu menuFile;
	private JMenu menuEdit;
	private JMenu menuPen;
	private JMenu menuShape;
	private JMenu menuHelp;
	private JMenu menushot;

	// “文件”菜单选项
	private JMenuItem mitmFileNew;
	private JMenuItem mitmFileOpen;
	private JMenuItem mitmFileSave;
	private JMenuItem mitmFileExit;

	// “编辑”菜单选项
	private JMenuItem mitmEditClear;

	// “画笔”菜单选项
	private JMenuItem mitmPenPencil;
	private JMenuItem mitmPenEraser;
	private JMenuItem mitmPenColor;
	private JMenuItem mitmPenWidth1p;
	private JMenuItem mitmPenWidth2p;
	private JMenuItem mitmPenWidth3p;
	private JMenuItem mitmPenWidth5p;
	private JMenu menuPenWidth;
	private JMenuItem mitmPenDash;
	private JMenuItem mitmPenLine;
	private JMenu menuPenType;

	// “形状”菜单选项
	private JMenuItem mitmShapeLine;
	private JMenuItem mitmShapeRect;
	private JMenuItem mitmShapeCircle;
	private JMenuItem mitmShapeArc;

	// “帮助”菜单选项
	private JMenuItem mitmHelpView;
	
	//“截屏”菜单选项
	private JMenuItem mitmshotView;

	private PaintBoard paintBoard; // 画图板
	private HelpDialog helpDialog;	//帮助窗口
	//private MainFrame frame;
	//private ScreenShot screenShot;
}
