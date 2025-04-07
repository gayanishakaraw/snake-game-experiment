window.keyCapture = {
    registerKeyHandler: function (dotNetHelper) {
        document.addEventListener("keydown", function (e) {
            // Prevent scrolling when arrow or space is pressed
            if (["ArrowUp", "ArrowDown", "ArrowLeft", "ArrowRight", " "].includes(e.key)) {
                e.preventDefault();
            }
            dotNetHelper.invokeMethodAsync("OnKeyDown", e.key);
        });
    }
};