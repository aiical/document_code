package cfg_work;

import java.awt.BorderLayout;
import java.awt.GridLayout;

import javax.swing.*;

public class HelpDialog extends JFrame {
	public HelpDialog() {
		
		JLabel lbl1 = new JLabel("����:�ܸ���");
		JLabel lbl3 = new JLabel("ʱ�䣺2015��6��");
		JLabel lbl4 = new JLabel("��������Ȩ��");
		
		JPanel pane = new JPanel();
		JPanel pane1 = new JPanel();
		pane1.setSize(80, 200);
		
		pane.setLayout(new GridLayout(4, 1));
		pane.add(lbl1);
		pane.add(lbl3);
		pane.add(lbl4);
		
		this.setTitle("��ͼ���");
		this.setSize(300, 200);
		this.setAlwaysOnTop(true);
		this.setLocation(400, 200);
		this.setResizable(false);
		
		this.add(BorderLayout.WEST, pane1);
		this.add(BorderLayout.CENTER, pane);
	}
}
