const IS_PRODUCTION = !0,
    store = new Vuex.Store({
        state: {
            fileInputState: null,
            liveInputState: null,
            savedCodes: []
        },
        mutations: {
            setFileInputState(e, t) {
                e.fileInputState = Object.assign({}, t),
                    localStorage.setItem("bytescout-barcode-reader-FILE_INPUT_STATE", JSON.stringify(t))
            },
            setLiveInputState(e, t) {
                e.liveInputState = Object.assign({}, t),
                    localStorage.setItem("bytescout-barcode-reader-LIVE_INPUT_STATE", JSON.stringify(t))
            },
            saveCode(e, t) {
                const o = JSON.parse(localStorage.getItem("bytescout-barcode-reader-SAVED_CODES")) || [];
                if (o.length > 0 && t) {
                    if ("" == t.code || "" == t.code.trim())
                        return;
                    if (o.find(e => e.code === t.code))
                        return
                }
                o.unshift(t),
                    e.savedCodes = o.slice(0),
                    localStorage.setItem("bytescout-barcode-reader-SAVED_CODES", JSON.stringify(e.savedCodes))
            },
            cleanCodes(e) {
                e.savedCodes = [],
                    localStorage.removeItem("bytescout-barcode-reader-SAVED_CODES")
            }
        },
        actions: {
            setFileInputState({ commit: e }, t) {
                e("setFileInputState", t)
            },
            setLiveInputState({ commit: e }, t) {
                e("setLiveInputState", t)
            },
            saveCode({ commit: e }, t) {
                document.getElementById("qrkodgelen").setAttribute("value", t.code);

                e("saveCode", t)
            },
            cleanCodes({ commit: e }, t) {
                e("cleanCodes")
            }
        },
        getters: {
            fileInputState() {
                const e = localStorage.getItem("bytescout-barcode-reader-FILE_INPUT_STATE");
                return e ? JSON.parse(e) : null
            },
            liveInputState() {
                const e = localStorage.getItem("bytescout-barcode-reader-LIVE_INPUT_STATE");
                return e ? JSON.parse(e) : null
            },
            savedCodes(e) {
                if (0 === e.savedCodes.length) {
                    const e = JSON.parse(localStorage.getItem("bytescout-barcode-reader-SAVED_CODES"));
                    if (e && e.length)
                        return e
                }
                return e.savedCodes
            }
        }
    });
window.console.log = function () { },
    window.console.error = function () { },
    window.console.warn = function () { },
    window.app = new Vue({
        el: "#app",
        store: store,
        components: {
            "file-input": FileInput,
            "live-input": LiveInput
        },
        data: () => ({
            tabIndex: 0,
            fields: [{
                key: "code",
                sortable: !0
            },
                {
                    key: "format",
                    sortable: !0
                },
                {
                    key: "scannedAt",
                    sortable: !0
                }]
        }),
        computed: {
            savedCodes() {
                return this.$store.getters.savedCodes
            }
        },
        methods: {
            cleanCodes() {
                this.$store.dispatch("cleanCodes")
            }
        }
    });