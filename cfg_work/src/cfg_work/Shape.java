package cfg_work;

import java.awt.Graphics2D;
import java.awt.Point;

//������ͼ��ͼ�νӿ�
interface Shape {
	public void draw(Graphics2D g, int X, int Y, int width, int height);
	public void draw(Graphics2D g, Point leftTop, Point rightBottom);
}

class Rectangle implements Shape {

	@Override
	public void draw(Graphics2D g, int X, int Y, int width, int height) {
		// TODO Auto-generated method stub
		g.drawRect(X, Y, width, height);
	}

	@Override
	public void draw(Graphics2D g, Point leftTop, Point rightBottom) {
		// TODO Auto-generated method stub
		DrawFactory.draw(this, g, leftTop, rightBottom);
	}
}

class Oval implements Shape {

	@Override
	public void draw(Graphics2D g, int X, int Y, int width, int height) {
		// TODO Auto-generated method stub
		g.drawOval(X, Y, width, height);
	}

	@Override
	public void draw(Graphics2D g, Point leftTop, Point rightBottom) {
		// TODO Auto-generated method stub
		DrawFactory.draw(this, g, leftTop, rightBottom);
	}
	
}

class Line implements Shape {

	@Override
	public void draw(Graphics2D g, int x1, int y1, int width, int height) {
		// TODO Auto-generated method stub
		g.drawLine(x1, y1, x1 + width, y1 + height);
	}

	@Override
	public void draw(Graphics2D g, Point leftTop, Point rightBottom) {
		// TODO Auto-generated method stub
		g.drawLine(leftTop.x, leftTop.y, rightBottom.x, rightBottom.y);
	}
	
}

//Ϊÿ����״�������겢����
class DrawFactory {
	public static void draw(Shape shape, Graphics2D g, Point leftTop, Point rightBottom) {
		//��������ʹ����Ƶ����ⷽ�򶼿��Ի�
		int x1 = Math.min(leftTop.x, rightBottom.x);
		int y1 = Math.min(leftTop.y, rightBottom.y);
		int width = Math.abs(rightBottom.x - leftTop.x);
		int height = Math.abs(rightBottom.y - leftTop.y);
		
		//
		shape.draw(g, x1, y1, width, height);
	}
}
