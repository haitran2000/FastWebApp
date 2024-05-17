
import { AtscadaDataResultPackage } from './atscada-data-result-package.js'

export class AtscadaDataReader {
    constructor(dataService) {
        this.dataService = dataService;
        // kye: TagName, value: package
        this.map = new Map();
        // so lan ket noi service, read tag toi da
        this.maxNumberOfRead = 3;
        // delay giua 2 lan doc lien tiep (khi bad)
        this.delayWhenTryRead = 1000;
    }

    // doc gia tri tag tu buffer (this.map)
    read(name) {
        if (this.map.has(name)) return this.map.get(name);
        const resultPackage = new AtscadaDataResultPackage();
        resultPackage['Name'] = name;
        return resultPackage;
    }

    // doc/ cpa nhat du lieu qua service
    async update(names) {
        this.map.clear();        
        var resultPackages;
        for (let i = 0; i < this.maxNumberOfRead; i++) {
            // read by service
            resultPackages = await this.dataService.read(names);
            if (resultPackages) {
                for (const resultPackage of resultPackages) {
                    if (resultPackage['Name'])
                        // cap nhat buffer
                        this.map.set(
                            resultPackage['Name'],
                            resultPackage);
                }
                break;
            }
            // delay neu ket noi that bai. return resolve
            await new Promise(resolve => setTimeout(resolve, this.delayWhenTryRead));
        }       
    }
}