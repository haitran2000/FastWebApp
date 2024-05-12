
// Giai ma Content tra ve de hien thi (View)
export class AtscadaAppRouterCompiler {
    // Giai ma ContentView
    // return View.Render (c#)
    decodeView(response) {
        response = response || {};
        if (!this.checkFailed(response)) {
            return response['Result'];
        }
        return undefined;
    }

    checkFailed(response) {
        return !response || !response['Status'] || !response['Result'];
    }
}