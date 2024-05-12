
// giai ma - ma hoa goi tin truyen Export
export class AtscadaExportCompiler{

    // Gia hoa du lieu tra ve tu Server. Xuat excel .xlsx
    decodeExcel(fileName, response) {
        response = response || {};        
        if (!this.checkFailed(response)) {
            // get buffer array of Excel File
            var buffer = window.atob(response['Result']);
            var data = new Uint8Array(buffer.length);
            for (var i = 0; i < buffer.length; i++) {
                data[i] = buffer.charCodeAt(i);
            }

            // Xuat excel tu Browser
            // tao the <a> de download file
            var downloadLink = window.document.createElement('a');
            downloadLink.href = window.URL.createObjectURL(new Blob([data], { type: 'application/octet-stream' }));
            downloadLink.download = `${fileName}.xlsx`;
            document.body.appendChild(downloadLink);
            downloadLink.click();
            document.body.removeChild(downloadLink);

            return true;
        }
        return false;
    }

    // ma hoa ID reporter can xuat Excel
    encodeExportParam(exportParam) {
        exportParam = exportParam || {};
        return {
            'ID': exportParam.id
        }
    }
    
    checkFailed(response) {
        return !response || !response['Status'] || !response['Result'];
    }
}