
export class AtscadaDataWriter {
    constructor(dataService, maxNumberOfWrite = 10) {
        this.dataService = dataService;
        this.maxNumberOfWrite = maxNumberOfWrite;
        this.map = new Map();        
    }

    // Ham tag.Write
    // Khi tag call ham write. Se add command write vao danh sach cho
    write(command) {
        command = command || {};
        if (!command.name) return;
        command.maxNumberOfWrite = this.maxNumberOfWrite;
        // key: name, value: command
        this.map.set(command.name, command);
    }

    // Ham ghi hang loat khi den chu ky quet
    async update() {
        // Kiem tra co comamand na can ghi hay khong
        if (this.map.size === 0) return;
        // ... this.map.values(): Tra ve mang Command
        const resultPackages = await this.dataService.write([...this.map.values()]);        
        for (const [name, command] of this.map) {
            // Cap nhat ket qua tra ve cho command
            const resultPackage = resultPackages.find(resultPackage =>
                resultPackage['Name'] === name);
            command.update(resultPackage);
            // Neu da hoan thanh thi xoa command khoi danh sach cho
            if (command.isCompleted) this.map.delete(name);
        }
    }
}