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
			// ����������Ϊ��ǰwindows���
			UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
		} catch (Exception e) {
		}

		DrawingBoard drawingBoard = new DrawingBoard();
		drawingBoard.setVisible(true);
	}

	// ���ļ���ѡ���¼�������
	class FileActionListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			int flag = -1; // ��ʾ�Ǹ�ѡ�����

			// �ж��¼���Դ
			if (e.getSource() == mitmFileNew)
				
				flag = 0;
			if (e.getSource() == mitmFileOpen)
				flag = 1;
			if (e.getSource() == mitmFileSave)
				flag = 2;
			if (e.getSource() == mitmFileExit)
				flag = 3;

			// �����¼�
			switch (flag) {
			// ���½���ѡ��************************
			case 0:
				paintBoard.clear();
				repaint();
				file = null;
				break;
			// ���򿪡�ѡ��************************
			case 1:
				openImage();
				break;
			// �����桱ѡ��************************
			case 2:
				save();
				break;
			// ���˳���ѡ��************************
			case 3:
				DrawingBoard.this.dispose();
				break;
			}
		}

	}

	// ���༭��ѡ���¼�������
	class EditActionListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			int flag = -1; // ��ʾ�ĸ�ѡ�����

			// �ж��¼���Դ
			if (e.getSource() == mitmEditClear)
				flag = 1;

			// �����¼�
			switch (flag) {
			// �������ѡ��************************
			case 1:
				paintBoard.clear();
				repaint();
				break;
			}
		}

	}

	// �����ʡ�ѡ���¼�������
	class PenActionListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			int flag = -1; // ��ʾ�ĸ�ѡ�����
			float width = 0; // ��¼ԭ�����ϸ

			// �ж��¼���Դ
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

			// �����¼�
			switch (flag) {
			// Ǧ��********************************
			case 0:
				paintBoard.setShape(null);
				break;
			// ��Ƥ********************************
			case 1:
				if (!paintBoard.getIsEraser()) // �����ǰ������Ƥ���ͱ���֮ǰ����ɫ
					paintBoard.beforColor = paintBoard.getColor();
				paintBoard.setShape(null);
				paintBoard.setIsEraser(true);
				paintBoard.setColor(Color.white);
				break;
			// ��ɫ********************************
			case 2:
				Color color = JColorChooser.showDialog(DrawingBoard.this, "��ɫ",
						Color.black);
				if (color != null)
					paintBoard.setColor(color);
				break;
			// ʵ��********************************
			case 3:
				width = paintBoard.getStroke().getLineWidth(); // ��¼ԭ���ʴ�ϸ
				paintBoard.setStroke(new BasicStroke(width));
				break;
			// ����********************************
			case 4:
				float[] dash = { 10, 10 };
				width = paintBoard.getStroke().getLineWidth();
				BasicStroke stroke = new BasicStroke(width,
						BasicStroke.CAP_BUTT, BasicStroke.JOIN_BEVEL, 1, dash,
						0);
				paintBoard.setStroke(stroke);
				break;
			// 1���ؿ�********************************
			case 5:
				setLineWidth(1); // �����������
				break;
			// 2���ؿ�******************************
			case 6:
				setLineWidth(2);
				break;
			// 3���ؿ�******************************
			case 7:
				setLineWidth(3);
				break;
			// 5���ؿ�******************************
			case 8:
				setLineWidth(5);
				break;
			}

		}
	}

	// ����״��ѡ���¼�������
	class ShapeActionListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			int flag = -1; // ��ʾ�ĸ�ѡ�����

			// �ж��¼���Դ
			if (e.getSource() == mitmShapeLine)
				flag = 0;
			if (e.getSource() == mitmShapeRect)
				flag = 1;
			if (e.getSource() == mitmShapeCircle)
				flag = 2;
			if (e.getSource() == mitmShapeArc)
				flag = 3;

			// �����¼�
			switch (flag) {
			// ֱ��********************************
			case 0:
				paintBoard.setShape(new Line());
				break;
			// ����********************************
			case 1:
				paintBoard.setShape(new Rectangle());
				break;
			// ��Բ********************************
			case 2:
				paintBoard.setShape(new Oval());
				break;
			// ��********************************
			case 3:

				break;

			}
		}

	}

	// ��������ѡ���¼�������
	class HelpActionListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			helpDialog.setVisible(true);
		}

	}
	
	//��������ѡ���¼�������
	class ShotActionListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			new ScreenShot();
		}

	}

	// ����������ϸ
	private void setLineWidth(int width) {
		float[] dash = paintBoard.getStroke().getDashArray(); // ��¼ԭ����������Ϣ

		paintBoard.setStroke(new BasicStroke(width, BasicStroke.CAP_BUTT,
				BasicStroke.JOIN_BEVEL, 1, dash, 0));
	}

	// ����ͼƬ
	private void save() {
		if (file == null) { // û�д��ļ�������Ҫ����Ϊ�µ��ļ�
			// ���û�ѡ��һ�����ļ�
			JFileChooser fileChooser = new JFileChooser();
			fileChooser.setFileFilter(filter);
			int result = fileChooser.showSaveDialog(this);

			if (result == JFileChooser.APPROVE_OPTION) {
				file = fileChooser.getSelectedFile();
				paintBoard.saveToFile(file);
			}

		} else { // ����Ϊԭ�ļ�
			paintBoard.saveToFile(file);
		}
	}

	// ��ͼƬ
	private void openImage() {

		JFileChooser fileChooser = new JFileChooser();
		fileChooser.setFileFilter(filter); // �趨������
		int result = fileChooser.showOpenDialog(fileChooser);

		if (result == JFileChooser.APPROVE_OPTION) { // �û�ѡ����һ����ȷ��ͼƬ
			file = fileChooser.getSelectedFile();
			paintBoard.setImage(file); // ����ͼƬ

			repaint();
		}

	}

	public DrawingBoard() {

		super("��ͼ");

		// ����������
		filter = new FileNameExtensionFilter("JPEG(*.jpg;*.jpeg)", "jpg",
				"jpeg");

		// ���ļ���ѡ��
		mitmFileNew = new JMenuItem("�½�");
		mitmFileOpen = new JMenuItem("��");
		mitmFileSave = new JMenuItem("����");
		mitmFileExit = new JMenuItem("�˳�");

		mitmFileNew.addActionListener(fileActionListener);
		mitmFileOpen.addActionListener(fileActionListener);
		mitmFileSave.addActionListener(fileActionListener);
		mitmFileExit.addActionListener(fileActionListener);

		menuFile = new JMenu("�ļ�");
		menuFile.add(mitmFileNew);
		menuFile.add(mitmFileOpen);
		menuFile.add(mitmFileSave);
		menuFile.add(mitmFileExit);

		// ���༭��ѡ��
		mitmEditClear = new JMenuItem("���");

		mitmEditClear.addActionListener(editActionListener);

		menuEdit = new JMenu("�༭");
		menuEdit.add(mitmEditClear);

		// �����ʡ�ѡ��
		mitmPenPencil = new JMenuItem("Ǧ��");
		mitmPenEraser = new JMenuItem("��Ƥ");
		mitmPenColor = new JMenuItem("��ɫ");
		mitmPenWidth1p = new JMenuItem("1 pixel");
		mitmPenWidth2p = new JMenuItem("2 pixel");
		mitmPenWidth3p = new JMenuItem("3 pixel");
		mitmPenWidth5p = new JMenuItem("5 pixel");

		menuPenWidth = new JMenu("��ϸ");
		menuPenWidth.add(mitmPenWidth1p);
		menuPenWidth.add(mitmPenWidth2p);
		menuPenWidth.add(mitmPenWidth3p);
		menuPenWidth.add(mitmPenWidth5p);
		mitmPenDash = new JMenuItem("����");
		mitmPenLine = new JMenuItem("ʵ��");
		menuPenType = new JMenu("��/ʵ");
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

		menuPen = new JMenu("����");
		menuPen.add(mitmPenPencil);
		menuPen.add(mitmPenEraser);
		menuPen.add(mitmPenColor);
		menuPen.add(menuPenType);
		menuPen.add(menuPenWidth);

		// ����״��ѡ��
		mitmShapeLine = new JMenuItem("ֱ��");
		mitmShapeRect = new JMenuItem("����");
		mitmShapeCircle = new JMenuItem("��Բ");
		mitmShapeArc = new JMenuItem("����");

		mitmShapeLine.addActionListener(shpaeActionListener);
		mitmShapeRect.addActionListener(shpaeActionListener);
		mitmShapeCircle.addActionListener(shpaeActionListener);
		mitmShapeArc.addActionListener(shpaeActionListener);

		menuShape = new JMenu("��״");
		menuShape.add(mitmShapeLine);
		menuShape.add(mitmShapeRect);
		menuShape.add(mitmShapeCircle);
		menuShape.add(mitmShapeArc);

		// ��������ѡ��
		mitmHelpView = new JMenuItem("�鿴����");
		mitmHelpView.addActionListener(helpActionListener);

		menuHelp = new JMenu("����");
		menuHelp.add(mitmHelpView);
		//����ѡ��
		mitmshotView=new JMenuItem("��������");
		mitmshotView.addActionListener(shotActionListener);
		
		menushot = new JMenu("����");
		menushot.add(mitmshotView);

		// �˵�
		menuBar = new JMenuBar();
		menuBar.add(menuFile);
		menuBar.add(menuEdit);
		menuBar.add(menuPen);
		menuBar.add(menuShape);
		menuBar.add(menuHelp);
		menuBar.add(menushot);

		// //����
		paintBoard = new PaintBoard();
		
		//��������
		helpDialog = new HelpDialog();

		// ��ʼ������
		this.setDefaultCloseOperation(EXIT_ON_CLOSE);
		this.setLocation(0, 0);
		this.setSize(1000, 700);
		this.setExtendedState(MAXIMIZED_BOTH); // �������
		this.setJMenuBar(menuBar);
		JScrollPane scrPane = new JScrollPane(); // �½�������
		scrPane.setViewportView(paintBoard);
		// ���õ���Ҫʱ��ʾ������
		scrPane.setHorizontalScrollBarPolicy(JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);
		scrPane.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED);
		this.add(scrPane);
	}

	// ˽����
	private File file = null; // ��ǰ�ļ�
	private FileNameExtensionFilter filter; // ��ʽ������

	// �¼�����
	FileActionListener fileActionListener = new FileActionListener();
	EditActionListener editActionListener = new EditActionListener();
	PenActionListener penActionListener = new PenActionListener();
	ShapeActionListener shpaeActionListener = new ShapeActionListener();
	HelpActionListener helpActionListener = new HelpActionListener();
	ShotActionListener shotActionListener = new ShotActionListener();

	// �������
	private JMenuBar menuBar; // �˵���

	// �˵�ѡ��
	private JMenu menuFile;
	private JMenu menuEdit;
	private JMenu menuPen;
	private JMenu menuShape;
	private JMenu menuHelp;
	private JMenu menushot;

	// ���ļ����˵�ѡ��
	private JMenuItem mitmFileNew;
	private JMenuItem mitmFileOpen;
	private JMenuItem mitmFileSave;
	private JMenuItem mitmFileExit;

	// ���༭���˵�ѡ��
	private JMenuItem mitmEditClear;

	// �����ʡ��˵�ѡ��
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

	// ����״���˵�ѡ��
	private JMenuItem mitmShapeLine;
	private JMenuItem mitmShapeRect;
	private JMenuItem mitmShapeCircle;
	private JMenuItem mitmShapeArc;

	// ���������˵�ѡ��
	private JMenuItem mitmHelpView;
	
	//���������˵�ѡ��
	private JMenuItem mitmshotView;

	private PaintBoard paintBoard; // ��ͼ��
	private HelpDialog helpDialog;	//��������
	//private MainFrame frame;
	//private ScreenShot screenShot;
}
