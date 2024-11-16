CREATE DATABASE QuizGame
GO
USE QuizGame
GO
CREATE TABLE Answers (AnswerID int IDENTITY PRIMARY KEY,
                      Answer varchar(20))
CREATE TABLE QuestionTypes (TypeID int IDENTITY PRIMARY KEY,
                            Type varchar(20))

CREATE TABLE Questions (QuestionID int IDENTITY,
                        Question varchar(250),
                        A varchar(100),
                        B varchar(100),
                        C varchar(100),
                        D varchar(100),
                        Answer int REFERENCES Answers(AnswerID),
                        QuestionType int REFERENCES QuestionTypes(TypeID))

SELECT * FROM Questions
SELECT * FROM QuestionTypes
SELECT * FROM Answers

INSERT INTO Answers VALUES ('A'),('B'),('C'),('D')
INSERT INTO QuestionTypes VALUES ('Easy'),('Hard')
SELECT DATABASEPROPERTYEX('QuizGame', 'Collation');

ALTER DATABASE QuizGame COLLATE Vietnamese_CI_AS;
ALTER TABLE Questions
ALTER COLUMN Question NVARCHAR(MAX) COLLATE Vietnamese_CI_AS;
ALTER TABLE Questions ALTER COLUMN Question NVARCHAR(MAX) COLLATE Vietnamese_CI_AS;
ALTER TABLE Questions ALTER COLUMN A NVARCHAR(255) COLLATE Vietnamese_CI_AS;
ALTER TABLE Questions ALTER COLUMN B NVARCHAR(255) COLLATE Vietnamese_CI_AS;
ALTER TABLE Questions ALTER COLUMN C NVARCHAR(255) COLLATE Vietnamese_CI_AS;
ALTER TABLE Questions ALTER COLUMN D NVARCHAR(255) COLLATE Vietnamese_CI_AS;
-- Insert the new questions into the Questions table
INSERT INTO Questions (Question, A, B, C, D, Answer, QuestionType) VALUES
(N'Mạnh vì..., bạo vì tiền', N'gạo', N'thóc', N'lúa', N'khoai', 1, 1),
(N'Gỗ mun có màu gì?', N'Vàng', N'Nâu', N'Xanh', N'Đen', 4, 1),
(N'Ngôi chùa được đúc hoàn toàn bằng đồng tại Việt Nam', N'chùa Hương', N'chùa chiền', N'chùa hang', N'chùa đồng', 4, 1),
(N'Sat trong tiếng Anh là thứ mấy trong tuần', N'thứ ba', N'thứ tư', N'thứ hai', N'thứ bảy', 4, 1),
(N'Người đẹp vì lụa, ... tốt vì phân', N'thóc', N'gạo', N'sắn', N'lúa', 4, 1),
(N'Người ta thường gọi quốc gia nào là đất nước mặt trời mọc', N'nước Nhật', N'nước Mĩ', N'nước Việt Nam ', N'nước Hàn', 1, 1),
(N'Người Việt Nam đầu tiên bay vào vũ trụ', N'Thạch Lam', N'Phạm Tuân', N'Hồ Chí Minh ', N'Tố Hữu', 2, 1),
(N'Con có cha như nhà có nóc, con không cha như... đứt đuôi', N'cóc', N'ếch', N'nòng nọng', N'nhái', 3, 1),
(N'Loại vật liệu dùng trong sản xuất thủy tinh', N'vàng', N'cát trắng', N'bạc', N'đồng', 2, 1),
(N'Chị em dâu như bầu...', N'nước ngọt', N'nước muối', N'nước lã', N'rượu', 3, 1),
(N'Loài động vật nào có 3 tim, 8 chi và máu màu xanh', N'bạch tuộc', N'ốc', N'cá', N'gà', 1, 1),
(N'Thăng Long Hà Nội 1000 tuổi vào năm nào?', N'2012', N'2010', N'2005', N'2024', 2, 1),
(N'Phương tiện nào sau đây ít giống với những cái còn lại?', N'oto', N'máy bay', N'Xe đạp', N'Xe đẩy', 2, 1),
(N'Biển có nồng độ muối lớn nhất thế giới?', N'biển Đỏ', N'biển Đông', N'biển Chết', N'biển báo', 3, 1),
(N'Huyện Võ Nhai thuộc tỉnh nào nước ta?', N'Lạng Sơn', N'Bắc Ninh', N'Hà Nội', N'Thái Nguyên ', 4, 1),
(N'Ở Chùa Bộc, ngoài thờ phật, nhân dân còn thờ vị tướng nào?', N'Vua Quang Trung ', N'vua Lý Thái Tổ', N'vua Lý Nhân Tông', N'vua Lê Lợi', 1, 2),
(N'Vua nào đặt nhiều niên hiệu nhất lịch sử nước ta', N'Lý Nhân Tông', N'Quang Trung', N'Lê Lợi', N'An Dương Vương', 1, 2),
(N'Quạ... thì ráo, sáo... thì mưa', N'ngủ', N'tắm', N'chạy', N'hót', 2, 2),
(N'Đây là hoạt động người dân bắc bộ làm để ngăn lũ lụt ', N'câu cá', N'chăn nuôi', N'đắp đê', N'đi học', 3, 2),
(N'Mưa chẳng qua... gió chẳng qua mùi', N'thìn', N'ngọ', N'mùi', N'thân', 2, 2),
(N'Hàm số nào không phải là hàm số chẵn', N'hàm số lượng giác', N'hàm bậc hai', N'hàm cosx.sinx', N'hàm bậc ba', 3, 2),
(N'Liên đoàn bóng đá Úc thuộc liên đoàn bóng đá nào?', N'Châu Á', N'Châu Mĩ', N'Châu Âu', N'Châu Phi', 1, 2),
(N'Tim người gồm bao nhiêu ngăn?', N'3', N'5', N'4', N'1', 3, 2),
(N'Câu nói: ""Đầu tôi chưa rơi xuống đất, xin bệ hạ đừng lo"" là của ai?', N'Trần Quốc Tuấn', N'Trần Thủ Độ', N'Đinh Bộ Lĩnh', N'Lê Lợi', 2, 2),
(N'Kinh thành trà kiệu thuộc tỉnh nào?', N'Quảng Ninh', N'Quảng Trị', N'Quảng Nam', N'Quảng Ngãi', 3, 2),
(N'Nhạc sĩ Sô Panh gắn liền với nhạc cụ nào?', N'piano ', N'sáo', N'kèn', N'loa', 1, 2),
(N'Quốc kỳ nào giống hệt quốc kỳ Indonexia nhưng ngược chiều', N'nước Mĩ', N'nước Anh', N'nước Ba Lan', N'Nước Trung Quốc ', 3, 2),
(N'Sau chiến tranh thế giới 2, phong trào giải phóng dân tộc nổi lên mạnh nhất ở đâu?', N'Châu Á', N'Châu Mĩ', N'Châu Phi', N'Châu Âu ', 3, 2),
(N'Đầu nhẹ, bụng nặng, có hình bán nguyệt trơn tru không thể ngã là con gì?', N'con mèo', N'con lật đật', N'con chó', N'con khỉ', 2, 2),
(N'Trên lông dưới lông, ở giữa không lông, phồng lên để ngắm, là con gì?', N'con ngươi', N'con mắt', N'con ốc sên', N'con muỗi ', 2, 2);
