include Config.mp3

BUILD := Debug
LINKER := $(CC)
BINDIR := ../bin/$(BUILD)/

CFLAGS :=-fPIC -Iimport.app -I$(MOTF_HEADER_PATH) -I$(X11_HEADER_PATH) 
LINK_LIBS := -Limport.app/lib -L$(MOTF_LIBRARY_PATH) $(MOTIF_LIBS) -L$(X11_LIBRARY_PATH) $(X11_LIBS)
LINK_FLAGS := -fPIC -g -shared
OPT := -g -D_DEBUG

# チェック
MOTIF_CHECK_C=iso.app/Contents/Resources/MotifCheck.c
MOTIF_CHECK_E=iso.app/Contents/MacOS/iso

LIB_CHECK_C=scripts.app/Contents/Resources/LibCheck.c
LIB_CHECK_E=scripts.app/Contents/MacOS/scripts

IMP_CHECK_C=import.app/Contents/Resources/ImpCheck.c
IMP_CHECK_E=import.app/Contents/MacOS/import

# 自動生成用
GEN_EXE := tmpfile.app/Contents/MacOS/gen
GEN_C := tmpfile.app/Contents/Resources/gen.c
GEN_SRC_DIR := ../TonNurako/Native/GEN
TEMPLATE_DIR := iso.app
SCRIPT_DIR := scripts.app

XM_CONSTANT_CS=$(GEN_SRC_DIR)/Xm.Constant.cs
XM_CONSTANT_CS_TPL=$(TEMPLATE_DIR)/Constant.iso

XM_RESOURCEID_CS=$(GEN_SRC_DIR)/Xm.ResourceId.cs
XM_RESOURCEID_CS_TPL=$(TEMPLATE_DIR)/ResourceId.iso

XM_STRINGCONSTANT_CS=$(GEN_SRC_DIR)/Xm.StringConstant.cs
XM_STRINGCONSTANT_CS_TPL=$(TEMPLATE_DIR)/StringConstant.iso


ifeq ($(BUILD),Release)
	OPT = -O2 -DNDEBUG
endif


OBJ=DlSym.o	\
 	ClassDef.o \
 	XmImport.o \
	XtImport.o  \
	X11Import.o \
    TonNurako.o \
	XmCreateFuncs.o

TARGET = $(BINDIR)libTonNurako.extremesports

.c.o:
	$(CC) $(OPT) $(CFLAGS) $(WARN_OPT) -c  $< -o $@

all: ExtremeSports GenSrc

ExtremeSports: Check $(TARGET)

$(TARGET): $(OBJ)
	$(LINKER) $(OBJ) $(LINK_LIBS) $(LINK_FLAGS) -o $(TARGET)

$(OBJ): $(OUTDIR)

$(OUTDIR):
	mkdir -p $(OUTDIR)

# ﾁｪｯｸ
Check: MotifCheck LibCheck ImportCheck

MotifCheck:
	$(CC) $(CFLAGS)  $(LINK_LIBS) -o $(MOTIF_CHECK_E) $(MOTIF_CHECK_C)
	$(MOTIF_CHECK_E)

LibCheck:
	$(CC) $(CFLAGS)  $(LINK_LIBS) -o $(LIB_CHECK_E) $(LIB_CHECK_C)
	$(LIB_CHECK_E)

ImportCheck:
	$(CC) $(CFLAGS)  $(LINK_LIBS) -o $(IMP_CHECK_E) $(IMP_CHECK_C)
	$(IMP_CHECK_E)



# ほほほ

GenSrc: $(XM_CONSTANT_CS) $(XM_RESOURCEID_CS) $(XM_STRINGCONSTANT_CS)

$(TEMP_BIN): 
	mkdir -p $(TEMP_BIN)

$(XM_CONSTANT_CS): $(XM_CONSTANT_CS_TPL)
	$(PYTHON) $(SCRIPT_DIR)/const.py $(XM_CONSTANT_CS_TPL) >$(GEN_C)
	$(CC) $(CFLAGS) $(LINK_LIBS) -o $(GEN_EXE) $(GEN_C)
	$(GEN_EXE) >$(XM_CONSTANT_CS)

$(XM_RESOURCEID_CS): $(XM_RESOURCEID_CS_TPL)
	$(PYTHON) $(SCRIPT_DIR)/resource.py $(XM_RESOURCEID_CS_TPL) >$(GEN_C)
	$(CC) $(CFLAGS) $(LINK_LIBS) -o $(GEN_EXE) $(GEN_C)
	$(GEN_EXE) >$(XM_RESOURCEID_CS)

$(XM_STRINGCONSTANT_CS): $(XM_STRINGCONSTANT_CS_TPL)
	$(PYTHON) $(SCRIPT_DIR)/str_const.py $(XM_STRINGCONSTANT_CS_TPL) >$(GEN_C)
	$(CC) $(CFLAGS) $(LINK_LIBS) -o $(GEN_EXE) $(GEN_C)
	$(GEN_EXE) >$(XM_STRINGCONSTANT_CS)


clean.lib:
	- rm -rf *.o
	- rm -rf $(TARGET)
	- rm -rf dep
	- rm -rf core

clean: clean.lib
	- rm $(MOTIF_CHECK_E) $(LIB_CHECK_E)
	- rm $(XM_CONSTANT_CS) $(XM_RESOURCEID_CS) $(XM_STRINGCONSTANT_CS)


