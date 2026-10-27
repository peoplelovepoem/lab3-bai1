using System;
using System.Collections.Generic;

public class HinhHoc
{
    public double DienTich { get; set; }
    public double ChuVi { get; set; }

    public virtual void tinhDienTichChuVi()
    {
    }

    public override string ToString()
    {
        return $"Diện tích: {Math.Round(DienTich, 2)}, Chu vi: {Math.Round(ChuVi, 2)}";
    }
}
public class HinhChuNhat : HinhHoc
{
    private double mChieuDai;
    private double mChieuRong;

    public double ChieuDai
    {
        get { return mChieuDai; }
        set { mChieuDai = value; }
    }

    public double ChieuRong
    {
        get { return mChieuRong; }
        set { mChieuRong = value; }
    }

    public HinhChuNhat() { }

    public HinhChuNhat(double chieuDai, double chieuRong)
    {
        mChieuDai = chieuDai;
        mChieuRong = chieuRong;
        tinhDienTichChuVi(); 
    }

    public override void tinhDienTichChuVi()
    {
        DienTich = mChieuDai * mChieuRong;
        ChuVi = (mChieuDai + mChieuRong) * 2;
    }

    public override string ToString()
    {
        return $"Hình chữ nhật [Dài: {mChieuDai}, Rộng: {mChieuRong}] -> " + base.ToString();
    }
}

public class HinhTron : HinhHoc
{
    private double mBanKinh;

    public double BanKinh
    {
        get { return mBanKinh; }
        set { mBanKinh = value; }
    }

    public HinhTron() { }

    public HinhTron(double banKinh)
    {
        mBanKinh = banKinh;
        tinhDienTichChuVi();
    }

    public override void tinhDienTichChuVi()
    {
        DienTich = Math.PI * mBanKinh * mBanKinh;
        ChuVi = 2 * Math.PI * mBanKinh;
    }

    public override string ToString()
    {
        return $"Hình tròn [Bán kính: {mBanKinh}] -> " + base.ToString();
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        HinhChuNhat hcn = new HinhChuNhat(5, 3);
        Console.WriteLine(hcn.ToString());

        HinhTron ht = new HinhTron(4);
        Console.WriteLine(ht.ToString());

        Console.WriteLine("\n----------------------------------\n");

        List<HinhHoc> danhSachHinh = new List<HinhHoc>();
        danhSachHinh.Add(new HinhChuNhat(10, 5));
        danhSachHinh.Add(new HinhTron(2.5));
        danhSachHinh.Add(new HinhChuNhat(7, 4));
        danhSachHinh.Add(new HinhTron(6));

        double tongDienTich = 0;
        double tongChuVi = 0;
        HinhChuNhat hcnMaxDienTich = null;
        HinhTron htMinChuVi = null;

        Console.WriteLine("Danh sách các hình học:");
        foreach (HinhHoc hinh in danhSachHinh)
        {
            Console.WriteLine(hinh.ToString());
            tongDienTich += hinh.DienTich;
            tongChuVi += hinh.ChuVi;

            if (hinh is HinhChuNhat)
            {
                HinhChuNhat currentHCN = (HinhChuNhat)hinh;
                if (hcnMaxDienTich == null || currentHCN.DienTich > hcnMaxDienTich.DienTich)
                {
                    hcnMaxDienTich = currentHCN;
                }
            }

            if (hinh is HinhTron)
            {
                HinhTron currentHT = (HinhTron)hinh;
                if (htMinChuVi == null || currentHT.ChuVi < htMinChuVi.ChuVi)
                {
                    htMinChuVi = currentHT;
                }
            }
        }

        Console.WriteLine("\n--- THỐNG KÊ ---");
        Console.WriteLine($"Tổng diện tích: {Math.Round(tongDienTich, 2)}");
        Console.WriteLine($"Tổng chu vi: {Math.Round(tongChuVi, 2)}");

        if (hcnMaxDienTich != null)
            Console.WriteLine($"\nHình chữ nhật diện tích lớn nhất:\n{hcnMaxDienTich}");

        if (htMinChuVi != null)
            Console.WriteLine($"\nHình tròn chu vi nhỏ nhất:\n{htMinChuVi}");

        Console.ReadLine();
    }
}