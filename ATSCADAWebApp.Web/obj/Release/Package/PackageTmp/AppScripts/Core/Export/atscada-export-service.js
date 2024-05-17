
import { AtscadaFetchService } from '../Common/atscada-fetch-service.js'
import { AtscadaExportCompiler } from './atscada-export-compiler.js'

// Service ket noi den controller
export class AtscadaExportService {
    constructor(timeout = 30000) {
        this.timeout = timeout;
        this.service = new AtscadaFetchService();
        this.compiler = new AtscadaExportCompiler();
    }

    // tra ve du lieu Array cua FileExcel AlarmrReport
    async getAlarmReport(exportParam) {
        const encodeParam = this.compiler.encodeExportParam(exportParam);
        const url = '/Export/GetAlarmReport';
        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(encodeParam),
            timeout: this.timeout
        };
        const response = await this.service.handler(url, options);
        return this.compiler.decodeExcel('AlarmReport', response);
    }

    // tra ve du lieu Array cua FileExcel DataReport
    async getDataReport(exportParam) {
        const encodeParam = this.compiler.encodeExportParam(exportParam);
        const url = '/Export/GetDataReport';
        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(encodeParam),
            timeout: this.timeout
        };
        const response = await this.service.handler(url, options);
        return this.compiler.decodeExcel('DataReport', response);
    }
    async getDataReportPDF(exportParam) {
        try {
            //// Gọi API để lấy dữ liệu PDF từ máy chủ
            //const response = await fetch('/Export/GetDataReportPDF', {
            //    method: 'POST',
            //    headers: {
            //        'Content-Type': 'application/json'
            //    },
            //    body: JSON.stringify(exportParam)
            //});
            const encodeParam = this.compiler.encodeExportParam(exportParam);
            const url = '/Export/GetDataReportPDF';
            const options = {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json;charset=utf-8'
                },
                body: JSON.stringify(encodeParam),
                timeout: this.timeout
            };
            const response = await this.service.handler(url, options);
            // Xử lý phản hồi từ API
            //const data = await response.json();
            //if (!data.Status) {
            //    throw new Error(data.Message || 'Có lỗi khi tải tệp PDF.');
            //}
            const linkSource = `data:application/pdf;base64,${response.Result}`;
            const downloadLink = document.createElement("a");
            const fileName = "DataReport.pdf";
            downloadLink.href = linkSource;
            downloadLink.download = fileName;
            document.body.appendChild(downloadLink);
            downloadLink.click();
            document.body.removeChild(downloadLink);
            //// Giải mã dữ liệu PDF từ mã Base64
            //const pdfByteArray = atob(data.PdfBase64);
            //const pdfBlob = new Blob([pdfByteArray], { type: 'application/pdf' });

            //// Tạo URL cho Blob (tệp PDF)
            //const pdfUrl = URL.createObjectURL(pdfBlob);

            //// Tạo một phần tử <a> để tải xuống tệp PDF
            //const a = document.createElement('a');
            //a.href = pdfUrl;
            //a.download = 'Data.pdf';
            //document.body.appendChild(a);
            //a.click();
            //document.body.removeChild(a);

            //// Giải phóng URL khi đã sử dụng xong
            //URL.revokeObjectURL(pdfUrl);
        } catch (error) {
            console.error('Error:', error);
            alert('Đã xảy ra lỗi khi tải tệp PDF.');
        }
        //const encodeParam = this.compiler.encodeExportParam(exportParam);
        //try {
        //    const encodeParam = this.compiler.encodeExportParam(exportParam);

        //    const options = {
        //        method: 'POST',
        //        headers: {
        //            'Content-Type': 'application/json;charset=utf-8'
        //        },
        //        body: JSON.stringify(encodeParam),
        //        timeout: this.timeout
        //    };

        //    // Gọi API bằng cách sử dụng this.service.handler và await
        //    const response = await this.service.handler(url, options);

        //    if (!response.ok) {
        //        throw new Error('Có lỗi khi tải tệp PDF.');
        //    }

        //    // Nhận dữ liệu PDF dưới dạng Blob
        //    const pdfBlob = await response.blob();

        //    // Tạo URL cho Blob (tệp PDF)
        //    const pdfUrl = URL.createObjectURL(pdfBlob);

        //    // Tạo một phần tử <a> để tải xuống tệp PDF
        //    const a = document.createElement('a');
        //    a.href = pdfUrl;
        //    a.download = 'Data.pdf';
        //    document.body.appendChild(a);
        //    a.click();
        //    document.body.removeChild(a);

        //    // Giải phóng URL khi đã sử dụng xong
        //    URL.revokeObjectURL(pdfUrl);
        //} catch (error) {
        //    console.error('Error:', error);
        //    alert('Đã xảy ra lỗi khi tải tệp PDF.');
        //}
        //const url = '/Export/GetDataReportPDF';
        //fetch('/Export/GetDataReportPDF', {
        //    method: 'POST',
        //    headers: {
        //        'Content-Type': 'application/json'
        //    },
        //    body: JSON.stringify(encodeParam)
        //})
        //    .then(response => {
        //        if (!response.ok) {
        //            throw new Error('Có lỗi khi tải tệp PDF.');
        //        }
        //        return response.blob();
        //    })
        //    .then(blob => {
        //        // Tạo URL cho Blob (tệp PDF)
        //        var url = URL.createObjectURL(blob);

        //        // Tạo một phần tử <a> để tải xuống tệp PDF
        //        var a = document.createElement('a');
        //        a.href = url;
        //        a.download = 'D.pdf';
        //        document.body.appendChild(a);
        //        a.click();
        //        document.body.removeChild(a);

        //        // Giải phóng URL khi đã sử dụng xong
        //        URL.revokeObjectURL(url);
        //    })
        //    .catch(error => {
        //        console.error('Error:', error);
        //        alert('Đã xảy ra lỗi khi tải tệp PDF.');
        //    });
        //const options = {
        //    method: 'POST',
        //    headers: {
        //        'Content-Type': 'application/json;charset=utf-8'
        //    },
        //    body: JSON.stringify(encodeParam),
        //    timeout: this.timeout
        //};
        //const response = await this.service.handler(url, options);
        //return this.compiler.decodeExcel('DataReport', response);
    }
}