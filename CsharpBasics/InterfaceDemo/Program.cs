using InterfaceDemo;

Document docs = new Document();
docs.Print();
docs.Draw();
docs.ShowDocument();

IPrintable pr = new Document();
pr.Print();